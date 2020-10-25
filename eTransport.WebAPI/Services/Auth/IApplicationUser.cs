using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services.Auth
{
    public interface IApplicationUser
    {
        Task<Database.User> checkUserLogin(string username, string password);
        Task<Database.User> updateIdentityUser(int id, Model.User user);
        Task<bool> updateIdenityUserRoles(int id, IEnumerable<string> RemoveRole, IEnumerable<string> AddRole);
        Task<Database.User> getUserById(int id);
        Task<Database.User> createUser(ApplicationUserCreateRequest user, string password);
        Task<IList<string>> getUserRoles(Database.User user);
    }
}
