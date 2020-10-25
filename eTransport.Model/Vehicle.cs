using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string LicencePlate { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public int SeatingCapacity { get; set; }
        public double TrunkVolume { get; set; }
        public int CarrierID { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public byte[] Image { get; set; }
        public int? VehicleDetailsID { get; set; }
        public Model.VehicleDetails VehicleDetails { get; set; }
    }
}
