using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CommentRatingInsertRequest
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ClientID { get; set; }
        public int FreightID { get; set; }
    }
}
