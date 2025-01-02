using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11.Interface
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(IRoom room, bool includesBreakfast, bool includesWiFi);
    }
}
