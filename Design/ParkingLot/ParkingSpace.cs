using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class ParkingSpace
    {
        public Vehicle Vehicle { get; set; }

        public string ParkingType { get; set; }

        public int ParkingAreaSize { get; set; }

        public int DistanceFromGate { get; set; }
    }
}
