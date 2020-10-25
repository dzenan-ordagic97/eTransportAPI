using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CityInsertRequest
    {
        public string Name { get; set; }
        public string PostalNumber { get; set; }
        public int CountryID { get; set; }
    }
}
