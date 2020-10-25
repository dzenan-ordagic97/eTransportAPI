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
    public class VehicleModelService : BaseCRUDService<Model.VehicleModel, Model.VehicleModel, Database.VehicleModel, Model.VehicleModel, Model.VehicleModel>
    {
        public VehicleModelService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
        //public override List<Model.VehicleModel> Get(VehicleModelSearchRequest search)
        //{
        //    var query = _context.Set<VehicleModel>().AsQueryable();
        //    var authUser = _authService.GetUserIdentity(_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
        //    query = query.Where(x => x.CarrierID == authUser.UserID);

        //    var list = query.Include(x => x.Carrier).Select(x => new Model.VehicleModel
        //    {
        //        Name = x.Name
        //    }).ToList();
        //    return list;
        //}
    }
}
