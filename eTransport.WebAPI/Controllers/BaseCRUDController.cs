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
    public class BaseCRUDController<T,TSearch,TInsert,TUpdate> : BaseController<T,TSearch>
    {
        public readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<T,TSearch,TInsert,TUpdate> service):base(service)
        {
            _service = service;
        }
        [HttpPost]
        public virtual ActionResult<T> Insert(TInsert request)
        {
            try
            {
                return _service.Insert(request);
            }
            catch (Exception err)
            {
                return BadRequest(new { message=err.Message });
            }
        }
        [HttpDelete("{id}")]
        public virtual ActionResult<T> Delete(int id)
        {
            try
            {
                return _service.Delete(id);
            }
            catch (Exception err)
            {
                return BadRequest(new { message = "Can't delete this record!" });
            }
        }
        [HttpPut("{id}")]
        public virtual T Update(int id, [FromBody]TUpdate request)
        {
            return _service.Update(id, request);
        }
    }
}