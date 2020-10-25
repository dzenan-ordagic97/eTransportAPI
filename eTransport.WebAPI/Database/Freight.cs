using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class Freight
    {
        public int FreightID { get; set; }
        public DateTime? AcceptDate { get; set; }
        public DateTime? TransportDate { get; set; }
        public decimal Price { get; set; }
        public double? Distance { get; set; }
        public bool? Finished { get; set; }
        public bool? IsRated { get; set; }
        public bool? IsPayed { get; set; }
        public bool? ClientAccepted { get; set; }

        public int CarrierID { get; set; }
        public Carrier Carrier { get; set; }

        public int? VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }

        public List<CommentRating> CommentRatings { get; set; }

    }
}
