using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.ML
{
    public class CarrierRating
    {
        public uint UserID { get; set; }
        public uint CarrierID { get; set; }
        public float Label { get; set; }
    }
}
