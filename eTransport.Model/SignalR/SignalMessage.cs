using System;

namespace eTransport.Model.SignalR
{
    public class SignalMessage
    {
        public int? To { get; set; }
        public int? HeaderId { get; set; }
        public string Message { get; set; }
        public DateTime Sent{ get; set; }
        public int? From { get; set; }
    }
}