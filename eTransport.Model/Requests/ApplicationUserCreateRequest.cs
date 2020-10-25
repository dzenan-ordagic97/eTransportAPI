using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class ApplicationUserCreateRequest
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Image { get; set; }

        public CarrierInsertRequest Carrier{ get; set; }
        public ClientInsertRequest  Client{ get; set; }
        public int? AddressID { get; set; }
        public Address Address { get; set; }
    }
}
