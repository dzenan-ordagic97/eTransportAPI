using eTransport.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class Address
    {
        public int AddressID { get; set; }
        public string Name { get; set; }
       
        public int CityID { get; set; }
        public City City { get; set; }

        public List<User> Users { get; set; }
    }
}
