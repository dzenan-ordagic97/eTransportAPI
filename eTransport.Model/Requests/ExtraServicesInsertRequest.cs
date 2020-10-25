using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class ExtraServicesInsertRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CarrierID { get; set; }
    }
}
