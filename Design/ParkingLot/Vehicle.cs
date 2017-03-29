using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class Vehicle
    {
        public bool IsRegisteredDisability { get; set; }

        public VehicleType VehicleType { get; set; }

        public string VehicleIdentificationNumber { get; set; }
    }
}
