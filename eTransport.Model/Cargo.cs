using System;
using System.Collections.Generic;
using System.Text;

namespace eTransport.Model
{
    public class Cargo
    {
        public int CargoID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double MaxHeight { get; set; }
        public double MaxWidth { get; set; }
        public bool IsUsed { get; set; }
        public byte[] Image { get; set; }
    }
}
