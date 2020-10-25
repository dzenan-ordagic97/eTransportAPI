using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CargoReservationInsertRequest
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDateTransport { get; set; }
        public DateTime EndDateTransport { get; set; }
        public int CargoID { get; set; }
        public int ClientID { get; set; }
        public int? ExtraServicesID { get; set; }


        public bool Accepted { get; set; }
        public int? FreightID { get; set; }
        public Freight Freight { get; set; }
        public bool? Finished { get; set; }
        public bool isClient { get; set; } = false;
        public bool isFreightUpdate { get; set; } = false;
    }
}
