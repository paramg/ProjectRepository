using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class ParkingTicket
    {
        public const decimal GracePeiodInHours = 0.25M;

        public DateTime ParkTime { get; set; }

        public decimal DurationInHours { get; set; }

        public decimal AmountPaid { get; set; }

        public bool Validate()
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(this.ParkTime);

            if(timeSpan.Hours > this.DurationInHours + ParkingTicket.GracePeiodInHours)
            {
                return false;
            }

            return true;
        }
    }
}
