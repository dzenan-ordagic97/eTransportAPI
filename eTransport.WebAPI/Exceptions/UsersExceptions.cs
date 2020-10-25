using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Exceptions
{
    public class UsersExceptions:Exception
    {
        public UsersExceptions(string message):base(message)
        {
        }
    }
}
