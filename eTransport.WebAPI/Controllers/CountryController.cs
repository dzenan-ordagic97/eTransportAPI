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
    [AllowAnonymous]
    public class CountryController : BaseCRUDController<Model.Country, Model.Country, Model.Requests.CountryInsertRequest, Model.Requests.CountryInsertRequest>
    {
        public CountryController(ICRUDService<Country, Country, Model.Requests.CountryInsertRequest, Model.Requests.CountryInsertRequest> service) : base(service)
        {
        }

    }
}