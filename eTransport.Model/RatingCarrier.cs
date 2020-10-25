using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
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
