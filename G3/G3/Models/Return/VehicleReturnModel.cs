using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G3.Models.Return
{
    public class VehicleReturnModel
    {
        public int VehicleId { get; set; }
        public string Vrm { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
        public bool IsTracked { get; set; }
    }
}
