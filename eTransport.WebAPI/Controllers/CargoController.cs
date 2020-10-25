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
    public class CargoController : BaseCRUDController<Model.Cargo, Model.Requests.CargoSearchRequest, Model.Requests.CargoInsertRequest, Model.Requests.CargoInsertRequest>
    {
        public CargoController(ICRUDService<Cargo, Model.Requests.CargoSearchRequest, Model.Requests.CargoInsertRequest, Model.Requests.CargoInsertRequest> service) : base(service)
        {
        }
    }
}
