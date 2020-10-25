using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class CargoReservation
    {
        public int CargoReservationID { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public bool Accepted { get; set; }
        public DateTime StartDateTransport { get; set; }
        public DateTime EndDateTransport { get; set; }
        public int ClientID { get; set; }
        public string Client { get; set; }
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }
        public int? FreightID{ get; set; }
        public Model.Freight Freight { get; set; }
        public int? ExtraServicesID { get; set; }
        public Model.ExtraServices ExtraServices { get; set; }
    }
}
