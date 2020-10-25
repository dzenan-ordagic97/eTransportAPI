using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : BaseCRUDController<Model.VehicleType, Model.VehicleType, Model.VehicleType, Model.VehicleType>
    {
        public VehicleTypeController(ICRUDService<VehicleType, VehicleType, VehicleType, VehicleType> service) : base(service)
        {
        }
    }
}