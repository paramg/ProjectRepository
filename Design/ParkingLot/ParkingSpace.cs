using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class ParkingSpace
    {
        public int ParkingNumber { get; set; }

        public bool IsReservedSpace { get; set; }

        public Vehicle Vehicle { get; set; }

        public string ParkingType { get; set; }

        public int ParkingAreaSize { get; set; }

        public int DistanceFromGate { get; set; }

        public bool IsAvailable { get; set; }
    }
}
