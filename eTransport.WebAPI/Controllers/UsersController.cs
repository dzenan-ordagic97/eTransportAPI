using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using eTransport.Model.Requests;
using eTransport.WebAPI.Services;
using eTransport.WebAPI.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        protected IUsersService _service;
        private readonly IAuthService _authService;

        public UsersController(IAuthService authService, IUsersService service)
        {
            _authService = authService;
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet("Auth")]
        public async Task<ActionResult<Model.User>> Auth()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return BadRequest(new { message = "Missing Authorization Header" });
            Model.User user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');

                var username = credentials[0];
                var password = credentials[1];
                user = await _authService.Authenticate(username, password);

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("Auth/Register")]
        public async Task<ActionResult<Model.User>> Register([FromBody] ApplicationUserCreateRequest user)
        {
            try
            {
                var res = await _authService.Register(user);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }
        [HttpGet]
        public IList<Model.User> GetAll([FromQuery]UserSearchRequest request)
        {
            return _service.GetAll(request);
        }

        [HttpGet("{id}")]
        public Model.User GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}