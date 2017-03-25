using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public class ParkingMeter
    {
        public IPaymentService PaymentService { get; set; }

        public const int AmountPerHour = 10;

        public bool PayCard(int numberOfHours)
        {
            int amount = numberOfHours * AmountPerHour;

            return this.PaymentService.PayByCard(amount, null);
        }

        public bool PayCash(int numberOfHours)
        {
            int amount = numberOfHours * AmountPerHour;

            return this.PaymentService.PayByCash(amount);
        }
    }
}
