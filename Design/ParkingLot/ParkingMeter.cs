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

        public const decimal AmountPerHour = 10.0M;

        public decimal GetAmountByDuration(int duration)
        {
            return AmountPerHour * duration;
        }

        public bool PayCard(decimal amount)
        {
            return this.PaymentService.PayByCard(amount, null);
        }

        public bool PayCash(decimal amount)
        { 
            return this.PaymentService.PayByCash(amount);
        }
    }
}
