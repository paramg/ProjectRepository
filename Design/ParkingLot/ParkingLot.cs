using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class ParkingLot
    {
        public List<ParkingSpace> ParkingSpaces { get; set; }

        public ParkingMeter ParkingMeter { get; set; }

        public string GateEntrance { get; set; }

        public ParkingSpace Park(Vehicle vehicle)
        {
            return new ParkingSpace();
        }
    }
}
