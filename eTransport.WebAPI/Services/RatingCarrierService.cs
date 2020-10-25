using AutoMapper;
using eTransport.Model.Requests;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class RatingCarrierService : BaseCRUDService<Model.RatingCarrier, Model.RatingCarrier, Database.RatingCarrier, Model.Requests.RatingCarrierInsertRequest, Model.RatingCarrier>
    {
        IAuthService _authService;
        public RatingCarrierService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override Model.RatingCarrier Insert(RatingCarrierInsertRequest request)
        {
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            var queryCommentRating = _context.Set<Database.CommentRating>().AsQueryable();
            var queryRatingCarrier = _context.Set<Database.RatingCarrier>().AsQueryable();
            bool trigger=false;
            foreach(var item in queryRatingCarrier)
            {
                if(item.ClientID==authUser.UserID && item.CarrierID==request.CarrierID)
                {
                    trigger = true;
                }
            }
            if (trigger == false)
            {
                queryCommentRating = queryCommentRating.Include(x => x.Freight);
                Database.RatingCarrier ratingCarrier = new Database.RatingCarrier()
                {
                    ClientID = authUser.UserID,
                    Rating = queryCommentRating.Where(y => y.Freight.CarrierID == request.CarrierID && y.ClientID==authUser.UserID).Select(x => x.Rating).Sum() / queryCommentRating.Where(y => y.Freight.CarrierID == request.CarrierID && y.ClientID == authUser.UserID).Select(x => x.Rating).Count(),
                    CarrierID = request.CarrierID
                };
                _context.RatingCarrier.Add(ratingCarrier);
                _context.SaveChanges();
                return _mapper.Map<Model.RatingCarrier>(ratingCarrier);
            }
            else
            {
                var old = _context.RatingCarrier.Where(y => y.CarrierID == request.CarrierID && y.ClientID==authUser.UserID).FirstOrDefault();
                old.ClientID = authUser.UserID;
                old.Rating = queryCommentRating.Where(y => y.Freight.CarrierID == request.CarrierID && y.ClientID == authUser.UserID).Select(x => x.Rating).Sum() / queryCommentRating.Where(y => y.Freight.CarrierID == request.CarrierID && y.ClientID == authUser.UserID).Select(x => x.Rating).Count();
                old.CarrierID = request.CarrierID;
                _context.SaveChanges();
                return _mapper.Map<Model.RatingCarrier>(old);
            }
        }
    }
}
