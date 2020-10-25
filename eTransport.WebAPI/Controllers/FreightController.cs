using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.Model;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreightController : BaseCRUDController<Model.Freight, Model.Requests.FreightSearchRequest, Model.Freight, Model.Requests.FreightInsertRequest>
    {
        public FreightController(ICRUDService<Freight, Model.Requests.FreightSearchRequest, Freight, Model.Requests.FreightInsertRequest> service) : base(service)
        {
        }
        //[AllowAnonymous]
        //[HttpGet("recommend")]
        //public List<Model.Freight> Recommend()
        //{
        //    return (_service as IFre).Recommend();
        //}
    }
}