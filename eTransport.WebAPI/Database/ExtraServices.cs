using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class ExtraServices
    {
        public int ExtraServicesID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int CarrierID { get; set; }
        public Carrier Carrier { get; set; }
    }
}
