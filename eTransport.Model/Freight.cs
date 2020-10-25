using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class Freight
    {
        public int FreightID { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? TransportDate { get; set; }
        public decimal Price { get; set; }
        public double? Distance { get; set; }
        //public string? TipPrijevoza { get; set; }
        public bool? Finished { get; set; }
        public bool? isRated { get; set; }
        public bool? isPayed { get; set; }
        public bool? ClientAccepted { get; set; }
        public string ClientAcceptedString { get; set; }



        public int CarrierID { get; set; }
        public Carrier Carrier { get; set; }

        public int? VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
