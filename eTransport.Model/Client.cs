using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class Client
    {
        public int ClientID { get; set; }
        public string JMBG { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
