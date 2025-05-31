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
        Approved =      0b0000_0010,
        Rejected =      0b0000_0100,
        Sold =          0b0000_1000,
        Rented =        0b0001_0000,
    }
}
