using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public partial class VehicleDetails
    {
        public int VehicleDetailsID { get; set; }
        public double MaxHeight { get; set; }
        public double MaxWeight { get; set; }
        public double MaxLength { get; set; }
        public double MaxWidth { get; set; }
        public decimal Price_per_km { get; set; }
        //public int? Br_EUPaleta { get; set; }
        public string Description { get; set; }
    }
}
