using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CargoReservationSearchRequest
    {
        public int CarrierID { get; set; }
        public bool isClient { get; set; } = false;
        public bool isFinished { get; set; } = false;
        public bool Payed { get; set; } = false;
        public bool isAccepted { get; set; } = false;
        public bool isExtraServiceDelete { get; set; } = false;


        public int ClientID { get; set; }
        public int ExtraServicesID { get; set; }

    }
}
