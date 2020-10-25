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
    public class VehicleTypeService : BaseCRUDService<Model.VehicleType, Model.VehicleType, Database.VehicleType, Model.VehicleType, Model.VehicleType>
    {

        public VehicleTypeService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
        //public override List<Model.VehicleType> Get(VehicleTypeSearchRequest search)
        //{
        //    var query = _context.Set<VehicleType>().AsQueryable();
        //    var list = query.Select(x => new Model.VehicleType
        //    {
        //        Name = x.Name
        //    }).ToList();
        //    return list;
        //}

    }
}
