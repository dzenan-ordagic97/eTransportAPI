using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public string PostalNumber { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
