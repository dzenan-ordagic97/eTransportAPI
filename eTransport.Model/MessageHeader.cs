using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class MessageHeader
    {
        public int MessageHeaderID { get; set; }
        public User From { get; set; }
        public int FromID { get; set; }
        public User To { get; set; }
        public int ToID { get; set; }
        public DateTime Sent { get; set; }
        public string Username { get; set; }
        public string LastMessage { get; set; }
        public bool Active { get; set; }
    }
}
