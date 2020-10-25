
using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class VehicleService : BaseCRUDService<Model.Vehicle, Model.Requests.VehicleSearchRequest, Database.Vehicle, Model.Requests.VehicleInsertRequest, Model.Requests.VehicleInsertRequest>
    {
        IAuthService _authService;
        public VehicleService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor,IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override Model.Vehicle Insert(VehicleInsertRequest request)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            Database.Vehicle vehicle = new Database.Vehicle()
            {
                CarrierID=authUser.UserID,
                VehicleTypeID=request.VehicleTypeID,
                VehicleModelID=request.VehicleModelID,
                TrunkVolume=request.TrunkVolume,
                Image=request.Image,
                LicencePlate=request.LicencePlate,
                SeatingCapacity=request.SeatingCapacity,
                YearOfManufacture=request.YearOfManufacture               
            };
            if (request.Details != null)
            {
                vehicle.VehicleDetails = new VehicleDetails()
                {
                    Description = request.Details.Description,
                    Price_per_km = request.Details.Price_per_km,
                    MaxWidth = request.Details.MaxWidth,
                    MaxWeight = request.Details.MaxWeight,
                    MaxLength = request.Details.MaxLength,
                    MaxHeight = request.Details.MaxHeight
                };
            }
            _context.Vehicle.Add(vehicle);
            _context.SaveChanges();
            return _mapper.Map<Model.Vehicle>(vehicle);
        }
        public override Model.Vehicle Update(int id, VehicleInsertRequest request)
        {
            var old = _context.Vehicle.Include(x=>x.VehicleDetails).Where(x => x.VehicleID == id).FirstOrDefault();
            if (old.VehicleDetails == null)
            {
                old.VehicleModelID = request.VehicleModelID;
                old.VehicleTypeID = request.VehicleTypeID;
                old.Image = request.Image;
                old.LicencePlate = request.LicencePlate;
                old.SeatingCapacity = request.SeatingCapacity;
                old.TrunkVolume = request.TrunkVolume;
                old.YearOfManufacture = request.YearOfManufacture;
                old.VehicleDetails = new VehicleDetails()
                {
                    MaxHeight = request.Details.MaxHeight,
                    Description=request.Details.Description,
                    MaxLength=request.Details.MaxLength,
                    MaxWeight=request.Details.MaxWeight,
                    MaxWidth=request.Details.MaxWidth,
                    Price_per_km=request.Details.Price_per_km,
                };
            }
            else
            {
                old.VehicleModelID = request.VehicleModelID;
                old.VehicleTypeID = request.VehicleTypeID;
                old.Image = request.Image;
                old.LicencePlate = request.LicencePlate;
                old.SeatingCapacity = request.SeatingCapacity;
                old.TrunkVolume = request.TrunkVolume;
                old.YearOfManufacture = request.YearOfManufacture;
                old.VehicleDetails.MaxHeight = request.Details.MaxHeight;
                old.VehicleDetails.MaxWeight = request.Details.MaxWeight;
                old.VehicleDetails.MaxLength = request.Details.MaxLength;
                old.VehicleDetails.MaxWidth = request.Details.MaxWidth;
                old.VehicleDetails.Price_per_km = request.Details.Price_per_km;
                old.VehicleDetails.Description = request.Details.Description;
            }
            _context.SaveChanges();
            return _mapper.Map<Model.Vehicle>(old);
        }
        public override List<Model.Vehicle> Get(VehicleSearchRequest search)
        {
            var query = _context.Set<Database.Vehicle>().AsQueryable();          
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            query = query.Where(x => x.CarrierID == authUser.UserID);

            var list = query.Include(x => x.VehicleType).Include(x => x.VehicleModel).Include(x => x.VehicleDetails).Include(x=>x.Carrier).Select(x => new Model.Vehicle
            {
                Image=x.Image,
                LicencePlate=x.LicencePlate,
                SeatingCapacity=x.SeatingCapacity,
                TrunkVolume=x.TrunkVolume,
                YearOfManufacture=x.YearOfManufacture,
                VehicleDetailsID=x.VehicleDetailsID,
                VehicleType = x.VehicleType.Name,
                VehicleModel = x.VehicleModel.Name,
                VehicleID = x.VehicleID,
                
                VehicleDetails = new Model.VehicleDetails()
                {
                    Description = x.VehicleDetails.Description,
                    Price_per_km = x.VehicleDetails.Price_per_km,
                    MaxWidth = x.VehicleDetails.MaxWidth,
                    MaxWeight = x.VehicleDetails.MaxWeight,
                    MaxLength = x.VehicleDetails.MaxHeight
                }

            }).ToList();

           return list;
        }
        public override Model.Vehicle GetById(int id)
        {
            var query = _context.Set<Database.Vehicle>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            query = query.Where(x => x.CarrierID == authUser.UserID);
            var vehicle = query.Include(x => x.VehicleType).Include(x => x.VehicleModel).Include(x => x.VehicleDetails).Include(x => x.Carrier).Where(x => x.VehicleID == id).FirstOrDefault();
            return _mapper.Map<Model.Vehicle>(vehicle);
        }
    }
}
