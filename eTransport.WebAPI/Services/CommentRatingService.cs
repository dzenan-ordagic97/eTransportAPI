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
    public class CommentRatingService : BaseCRUDService<Model.CommentRating, Model.Requests.CommentRatingSearchRequest, Database.CommentRating, Model.CommentRating, Model.CommentRating>
    {
        IAuthService _authService;
        public CommentRatingService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService service) : base(context, mapper, httpContextAccessor)
        {
            _authService = service;
        }
        public override List<Model.CommentRating> Get(CommentRatingSearchRequest search)
        {
            var query = _context.Set<Database.CommentRating>().AsQueryable();
            var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);

            if (search.isClient == true)
            {
                query = query.Where(x => x.ClientID == authUser.UserID);
                var list = query.Include(x => x.Freight).ThenInclude(x => x.Carrier).Select(x => new Model.CommentRating
                {
                    Comment = x.Comment,
                    Rating = x.Rating,
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        FreightID = x.Freight.FreightID,
                        TransportDate = x.Freight.TransportDate,
                        Price = x.Freight.Price,
                        CarrierID = x.Freight.CarrierID,
                        Carrier=new Model.Carrier()
                        {
                            CarrierName=x.Freight.Carrier.CarrierName
                        }
                    },
                    ClientID=x.ClientID
                }).ToList();
                return list;
            }
            else
            {
                query = query.Include(x => x.Freight).Where(x => x.Freight.CarrierID == authUser.UserID);
                var list = query.Include(x => x.Freight).ThenInclude(x => x.Carrier).Include(x => x.Client).Select(x => new Model.CommentRating
                {
                    Comment = x.Comment,
                    Rating = x.Rating,
                    FreightID = x.FreightID,
                    Freight = new Model.Freight()
                    {
                        FreightID = x.Freight.FreightID,
                        TransportDate = x.Freight.TransportDate,
                        Price = x.Freight.Price,
                        CarrierID = x.Freight.CarrierID,
                        Carrier = new Model.Carrier()
                        {
                            CarrierName = x.Freight.Carrier.CarrierName
                        }
                    },
                    Client = x.Client.FirstName + " " + x.Client.LastName
                }).ToList();
                return list;
            }

        }
    }
}
