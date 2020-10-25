using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class Carrier
    {
        public int CarrierID { get; set; }
        public string CarrierName { get; set; }
        public string CarrierBusinessEmail { get; set; }
        public string DriverLicenceNumber { get; set; }
        public string BusinessNumber { get; set; }
        public decimal StartupPrice { get; set; }
        public byte[] Image { get; set; }
        public float Rating { get; set; } = 0;
    }
}
