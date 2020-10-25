using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class ExtraServices
    {
        public int ExtraServicesID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CarrierID { get; set; }
    }
}
