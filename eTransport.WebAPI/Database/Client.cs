using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class Client
    {
        [ForeignKey("User")]
        public int ClientID { get; set; }
        public string JMBG { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public User User { get; set; }
        public List<Cargo> Cargos { get; set; }

    }
}
