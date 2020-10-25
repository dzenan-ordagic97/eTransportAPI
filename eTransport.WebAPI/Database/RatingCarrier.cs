using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public class RatingCarrier
    {
        public int RatingCarrierID { get; set; }
        public float Rating { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int CarrierID { get; set; }
        public Carrier Carrier { get; set; }
    }
}
