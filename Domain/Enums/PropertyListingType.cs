using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    [Flags]
    public enum PropertyListingType
    {
        Sale = 0b0000_0001,
        Rent = 0b0000_0010,
        Exchange = 0b0000_0100,
        SaleAndRent = Sale & Rent,
    }
}
