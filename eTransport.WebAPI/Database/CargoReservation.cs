using eTransport.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class CargoReservation
    {
        public int CargoReservationID { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public bool Accepted { get; set; }
        public DateTime StartDateTransport { get; set; }
        public DateTime EndDateTransport { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int? FreightID { get; set; }
        public Freight Freight { get; set; }

        public int? ExtraServicesID { get; set; }
        public ExtraServices ExtraServices { get; set; }

        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }

    }
}
