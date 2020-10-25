using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public string PostalNumber { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }
}
