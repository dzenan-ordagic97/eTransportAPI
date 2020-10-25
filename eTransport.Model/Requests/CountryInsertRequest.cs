using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CountryInsertRequest
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int CityID { get; set; }
    }
}
