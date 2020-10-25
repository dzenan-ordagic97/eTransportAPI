using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class ClientInsertRequest
    {
        public string JMBG { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
