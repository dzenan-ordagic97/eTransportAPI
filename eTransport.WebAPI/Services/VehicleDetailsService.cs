using AutoMapper;
using eTransport.WebAPI.Database;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public class VehicleDetailsService : BaseCRUDService<Model.VehicleDetails, Model.VehicleDetails, Database.VehicleDetails, Model.VehicleDetails, Model.VehicleDetails>
    {
        public VehicleDetailsService(eTransportContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
        }
    }
}
