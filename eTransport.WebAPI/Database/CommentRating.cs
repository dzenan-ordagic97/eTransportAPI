using eTransport.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class CommentRating
    {
        public int CommentRatingID { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int FreightID { get; set; }
        public Freight Freight { get; set; }

        //public int RatingCarrierID { get; set; }
        //public RatingCarrier RatingCarrier { get; set; }
    }
}
