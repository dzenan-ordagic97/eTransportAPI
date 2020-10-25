using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class Vehicle
    {
        public int VehicleID { get; set; }
        public string LicencePlate { get; set; }
        public DateTime YearOfManufacture { get; set; }
        public int SeatingCapacity { get; set; }
        public double TrunkVolume { get; set; }
        public byte[] Image { get; set; }


        public int CarrierID { get; set; }
        public Carrier Carrier { get; set; }

        public int VehicleTypeID { get; set; }
        public VehicleType VehicleType { get; set; }

        public int VehicleModelID { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public int? VehicleDetailsID { get; set; }
        public VehicleDetails VehicleDetails { get; set; }

        public List<Freight> Freights { get; set; }
    }
}
