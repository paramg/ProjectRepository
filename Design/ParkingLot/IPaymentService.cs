using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Libraries.ParkingLot
{
    public interface IPaymentService
    {
        bool PayByCash(int amount);

        bool PayByCard(int amount, dynamic cardInformation);
    }
}
