using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    [Flags]
    public enum PropertyStatusEnum
    {
        Pending =       0b0000_0001,
        ForSale =       0b0000_0010,
        ForRent =       0b0000_0100,
        Sold =          0b0000_1000,
        Rented =        0b0001_0000,
        Soon =          0b0010_0000,
        Unavailable =   0b0100_0000,

        ForSaleOrRent = ForSale & ForRent,



    }
}
