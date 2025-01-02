using Lession11.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11
{
    public class DefaultPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(IRoom room, bool includesBreakfast, bool includesWiFi)
        {
            decimal price = room.BasePrice;
            if (includesBreakfast) price += 20m;
            if (includesWiFi) price += 10m;
            return price;
        }
    }
}
