using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.Model;
using eTransport.Model.Requests;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : BaseCRUDController<Model.Carrier, Model.Requests.CarrierSearchRequest, Model.Carrier, Model.Requests.CarrierInsertRequest>
    {
        public CarrierController(ICRUDService<Carrier, CarrierSearchRequest, Carrier, CarrierInsertRequest> service) : base(service)
        {
        }
        [AllowAnonymous]
        [HttpGet("recommend")]
        public List<Model.Carrier> Recommend()
        {
            return (_service as ICarrierService).Recommend();
        }
    }
}