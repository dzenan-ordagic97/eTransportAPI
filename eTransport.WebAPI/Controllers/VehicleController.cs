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
    public class VehicleController : BaseCRUDController<Model.Vehicle, Model.Requests.VehicleSearchRequest, Model.Requests.VehicleInsertRequest, Model.Requests.VehicleInsertRequest>
    {
        public VehicleController(ICRUDService<Vehicle, VehicleSearchRequest, VehicleInsertRequest, VehicleInsertRequest> service) : base(service)
        {
        }
    }
}