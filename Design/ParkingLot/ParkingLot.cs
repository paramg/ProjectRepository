using DataStructures.Libraries.PriorityQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class ParkingLot
    {
        private const int ParkingNumberStarIndex = 100;
        private const int ParkingSize = 100;
        private const int DistanceFromPoleGate = 50; // In Feet

        public PriorityQueue<int, ParkingSpace> AvailableSpaces { get; set; }
        public List<ParkingSpace> ParkingSpaces { get; set; }
        public ParkingMeter ParkingMeter { get; set; }

        public ParkingLot()
        {
            this.AvailableSpaces = new PriorityQueue<int, ParkingSpace>(ParkingLot.ParkingSize);

            this.Initialize();
        }

        public void Initialize()
        {
            for(int i=0; i < ParkingLot.ParkingSize; i++)
            {
                ParkingSpace parkingSpace = new ParkingSpace();
                parkingSpace.DistanceFromGate = ParkingLot.DistanceFromPoleGate + i;
                parkingSpace.Vehicle.VehicleType = VehicleType.Compact;
                parkingSpace.ParkingNumber = ParkingLot.ParkingNumberStarIndex + i;
                
                // Assign three parking space for reserved.
                if(i == 0 || i == 1 || i == 2)
                {
                    parkingSpace.IsReservedSpace = true;
                }

                this.AvailableSpaces.Insert(parkingSpace.DistanceFromGate, parkingSpace);
            }
        }

        public ParkingSpace GetParkingSpace(Vehicle vehicle)
        {
            // Retrieve the parking space from the available spaces.
            // This will look up from Priority queue and gets the available spaces.
            ParkingSpace space = this.AvailableSpaces.Get();

            if (!vehicle.IsRegisteredDisability)
            {
                // By default the reserved space will be picked as this is high pri in the queue.
                while (space.IsReservedSpace)
                {
                    space = this.AvailableSpaces.Get();
                }
            }

            // The available space now can be deleted.
            var deletedSpace = this.AvailableSpaces.Delete();

            if(space.ParkingNumber != deletedSpace.ParkingNumber)
            {
                throw new Exception("The deleted space is invalid!");
            }

            // Set the vehicle to the parking space.
            space.Vehicle = vehicle;

            return space;
        }

        public void Pay(int durationInHours, PaymentType paymentType)
        {
            decimal amount = this.ParkingMeter.GetAmountByDuration(durationInHours);

            if(paymentType == PaymentType.PayByCard)
            {
                this.ParkingMeter.PayCard(amount);
            }
            else if(paymentType == PaymentType.PayByCash)
            {
                this.ParkingMeter.PayCash(amount);
            }
            else
            {
                throw new NotSupportedException("Payment type unknown.");
            }
        }
    }
}
