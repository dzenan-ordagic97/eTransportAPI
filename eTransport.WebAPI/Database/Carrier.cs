using eTransport.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class Carrier
    {
        [ForeignKey("User")]
        public int CarrierID { get; set; }
     
        public string CarrierName { get; set; }
        public string CarrierBusinessEmail { get; set; }
        public string DriverLicenceNumber { get; set; }
        public string BusinessNumber { get; set; }
        public decimal StartupPrice { get; set; }
        public byte[] Image { get; set; }

        public User User { get; set; }

        public List<Freight> Freights { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<ExtraServices> ExtraServices { get; set; }

    }
}
