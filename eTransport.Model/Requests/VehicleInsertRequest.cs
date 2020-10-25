using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class VehicleInsertRequest
    {
        public string LicencePlate { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public int SeatingCapacity { get; set; }
        public double TrunkVolume { get; set; }
        public int CarrierID { get; set; }
        public int VehicleTypeID { get; set; }
        public int VehicleModelID { get; set; }
        public byte[] Image { get; set; }
        public Model.VehicleDetails Details { get; set; }
    }
}
