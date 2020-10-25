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
    public class VehicleModelController : BaseCRUDController<Model.VehicleModel, Model.VehicleModel, Model.VehicleModel, Model.VehicleModel>
    {
        public VehicleModelController(ICRUDService<VehicleModel, VehicleModel, VehicleModel, VehicleModel> service) : base(service)
        {
        }
    }
}