using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public bool Seen { get; set; }
        public bool Recieved { get; set; }
        public int MessageHeaderID { get; set; }
        public bool IsTextIn { get; set; }
        public bool IsMyMessage { get; set; }
    }
}
