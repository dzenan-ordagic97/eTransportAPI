using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Services
{
    public interface IUsersService
    {
        IList<Model.User> GetAll(UserSearchRequest request);
        Model.User GetById(int id);
        Model.User Insert(UserInsertRequest request);
    }
}
