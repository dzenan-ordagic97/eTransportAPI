using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CarrierSearchRequest
    {
        public int? CarrierID { get; set; }
        public bool IsSingleCarrier { get; set; } = true;
    }
}
