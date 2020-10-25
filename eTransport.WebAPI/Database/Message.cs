using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }

        public int MessageHeaderID { get; set; }
        public MessageHeader MessageHeader { get; set; }
    }
}
