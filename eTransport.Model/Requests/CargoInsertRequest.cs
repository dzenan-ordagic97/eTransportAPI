using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model.Requests
{
    public class CargoInsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double MaxHeight { get; set; }
        public double MaxWidth { get; set; }
        public byte[] Image { get; set; }
        public int ClientID { get; set; }
        public bool IsUsed { get; set; }
        public bool isUpdate { get; set; }
    }
}
