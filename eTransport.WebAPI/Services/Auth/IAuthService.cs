using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace eTransport.WebAPI.Services.Auth
{
    public interface IAuthService
    {
        Task<Model.User> Authenticate(string username, string password);
        Task<Model.User> Register(Model.Requests.ApplicationUserCreateRequest user);
        Model.UserIdentity GetUserIdentity(ClaimsIdentity claimsIdentity);
    }
}
