using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.ML;
using eTransport.WebAPI.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class CarrierService : BaseCRUDService<Model.Carrier, Model.Requests.CarrierSearchRequest, Database.Carrier, Model.Carrier, Model.Requests.CarrierInsertRequest>, ICarrierService
    {
        IAuthService _authService;
        public CarrierService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override List<Model.Carrier> Get(CarrierSearchRequest search)
        {
            var query = _context.Set<Database.Carrier>().AsQueryable();
            var query2 = _context.Set<Database.CommentRating>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            if (search.CarrierID == 0)
            {
                search.CarrierID = null;
            }
            if (search.IsSingleCarrier == false && search.CarrierID != null)
            {
                var list = query.Include(x => x.User).Where(x => x.CarrierID == search.CarrierID).Select(x => new Model.Carrier
                {
                    Image = x.Image,
                    BusinessNumber = x.BusinessNumber,
                    CarrierBusinessEmail = x.CarrierBusinessEmail,
                    CarrierName = x.CarrierName,
                    DriverLicenceNumber = x.DriverLicenceNumber,
                    CarrierID = x.CarrierID,
                    StartupPrice = x.StartupPrice
                }).ToList();
                return list;
            }
            else if (search.IsSingleCarrier == false)
            {
                var list = query.Include(x => x.User).Select(x => new Model.Carrier
                {
                    Image = x.Image,
                    BusinessNumber = x.BusinessNumber,
                    CarrierBusinessEmail = x.CarrierBusinessEmail,
                    CarrierName = x.CarrierName,
                    DriverLicenceNumber = x.DriverLicenceNumber,
                    CarrierID = x.CarrierID,
                    StartupPrice = x.StartupPrice,
                    Rating = query2.Include(y => y.Freight).ThenInclude(y => y.Carrier).Where(y => y.Freight.CarrierID == x.CarrierID).Select(y => y.Rating).Sum() / query2.Include(y => y.Freight).ThenInclude(y => y.Carrier).Where(y => y.Freight.CarrierID == x.CarrierID).Select(y => y.Rating).Count()
                }).ToList();
                return list;
            }
            else
            {
                query = query.Where(x => x.CarrierID == authUser.UserID);
                var list = query.Include(x => x.User).Select(x => new Model.Carrier
                {
                    Image = x.Image,
                    BusinessNumber = x.BusinessNumber,
                    CarrierBusinessEmail = x.CarrierBusinessEmail,
                    CarrierName = x.CarrierName,
                    DriverLicenceNumber = x.DriverLicenceNumber,
                    CarrierID = x.CarrierID,
                    StartupPrice = x.StartupPrice
                }).ToList();
                return list;
            }
        }

        public List<Model.Carrier> Recommend()
        {
            MLContext mlContext = new MLContext();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            var id = authUser.UserID;
            var queryCommentRating = _context.Set<Database.CommentRating>().AsQueryable();

            var tmpCarrierRatings = _context.RatingCarrier.ToList();
            var data = new List<CarrierRating>();
            foreach (var item in tmpCarrierRatings)
            {
                data.Add(new CarrierRating() { CarrierID = (uint)item.CarrierID, UserID = (uint)item.ClientID, Label = item.Rating });
            }
            if (data.Count == 0)
            {
                return new List<Model.Carrier>();
            }
            var traindata = mlContext.Data.LoadFromEnumerable(data);

            var dataProcessingPipeline = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: nameof(CarrierRating.UserID))
                .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "carrierIdEncoded", inputColumnName: nameof(CarrierRating.CarrierID)));

            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = "userIdEncoded";
            options.MatrixRowIndexColumnName = "carrierIdEncoded";
            options.LabelColumnName = "Label";
            options.NumberOfIterations = 20;
            options.ApproximationRank = 100;

            var trainingPipeLine = dataProcessingPipeline.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            ITransformer model = trainingPipeLine.Fit(traindata);

            var allCarriers = _context.Carrier.ToList();
            var predictionResult = new List<Tuple<Database.Carrier, float>>();

            foreach (var item in allCarriers)
            {
                var predictionengine = mlContext.Model.CreatePredictionEngine<CarrierRating, CarrierRatingPrediction>(model);
                var prediction = predictionengine.Predict(
                                         new CarrierRating()
                                         {
                                             UserID = (uint)id,
                                             CarrierID = (uint)item.CarrierID
                                         });

                predictionResult.Add(new Tuple<Database.Carrier, float>(item, prediction.Score));
            }
            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(3).ToList();

            var final = new List<Model.Carrier>();
            foreach (var item in finalResult)
            {
                var carrier = _context.Carrier.Where(x => x.CarrierID == item.CarrierID).Select(t => new Model.Carrier
                {
                    CarrierID = t.CarrierID,
                    BusinessNumber = t.BusinessNumber,
                    CarrierBusinessEmail = t.CarrierBusinessEmail,
                    CarrierName = t.CarrierName,
                    DriverLicenceNumber = t.DriverLicenceNumber,
                    Image = t.Image,
                    Rating = queryCommentRating.Include(y => y.Freight).ThenInclude(y => y.Carrier).Where(y => y.Freight.CarrierID == item.CarrierID).Select(y => y.Rating).Sum() / queryCommentRating.Include(y => y.Freight).ThenInclude(y => y.Carrier).Where(y => y.Freight.CarrierID == item.CarrierID).Select(y => y.Rating).Count()
                }).FirstOrDefault();

                final.Add(carrier);
            }
            return _mapper.Map<List<Model.Carrier>>(final);
        }

        public override Model.Carrier Update(int id, CarrierInsertRequest request)
        {
            var old = _context.Carrier.Where(x => x.CarrierID == id).FirstOrDefault();
            old.CarrierName = request.CarrierName;
            old.DriverLicenceNumber = request.DriverLicenceNumber;
            old.CarrierBusinessEmail = request.CarrierBusinessEmail;
            old.BusinessNumber = request.BusinessNumber;
            old.Image = request.Image;
            old.StartupPrice = request.StartupPrice;
            _context.SaveChanges();
            return _mapper.Map<Model.Carrier>(old);
        }
        public override Model.Carrier GetById(int id)
        {
            var query = _context.Set<Database.Carrier>().AsQueryable();
            var carrier = query.Where(x => x.CarrierID == id).FirstOrDefault();
            return _mapper.Map<Model.Carrier>(carrier);
        }
    }
}
