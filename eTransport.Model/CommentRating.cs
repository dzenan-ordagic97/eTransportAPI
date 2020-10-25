using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class CommentRating
    {
        public int CommentRatingID { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
        public int FreightID { get; set; }
        public Freight Freight { get; set; }
        public int ClientID { get; set; }
        public string Client { get; set; }
    }
}
