using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace eTransport.WebAPI.Database
{
    public partial class User:IdentityUser<int>
    {
        public int? AddressID { get; set; }
        public Address Address { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual Client Client { get; set; }

        public string SignalRToken { get; set; }
        public bool Active { get; set; }
        public DateTime LastActiveAt { get; set; }

    }
}
