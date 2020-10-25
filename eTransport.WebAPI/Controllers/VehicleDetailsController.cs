using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.Model;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailsController : BaseCRUDController<Model.VehicleDetails, Model.VehicleDetails, Model.VehicleDetails, Model.VehicleDetails>
    {
        public VehicleDetailsController(ICRUDService<VehicleDetails, VehicleDetails, VehicleDetails, VehicleDetails> service) : base(service)
        {
        }
    }
}