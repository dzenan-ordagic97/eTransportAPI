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
    [AllowAnonymous]
    public class CityController : BaseCRUDController<Model.City, Model.Requests.CitySearchRequest, Model.Requests.CityInsertRequest, Model.Requests.CityInsertRequest>
    {
        public CityController(ICRUDService<City, CitySearchRequest, CityInsertRequest, CityInsertRequest> service) : base(service)
        {
        }
    }
}