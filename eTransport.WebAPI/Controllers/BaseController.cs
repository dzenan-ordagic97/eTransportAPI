using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TSearch> : ControllerBase
    {
        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T,TSearch> service)
        {
            _service = service;
        }
        [HttpGet]
        public virtual List<T> Get([FromQuery]TSearch search)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public virtual T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}