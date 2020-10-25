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
    public class ExtraServicesController : BaseCRUDController<Model.ExtraServices, Model.Requests.ExtraServicesSearchRequest, Model.Requests.ExtraServicesInsertRequest, Model.Requests.ExtraServicesInsertRequest>
    {
        public ExtraServicesController(ICRUDService<ExtraServices, Model.Requests.ExtraServicesSearchRequest, Model.Requests.ExtraServicesInsertRequest, Model.Requests.ExtraServicesInsertRequest> service) : base(service)
        {
        }
    }
}