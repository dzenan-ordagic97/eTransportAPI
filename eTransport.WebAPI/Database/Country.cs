using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public List<City> Cities { get; set; }
    }
}
