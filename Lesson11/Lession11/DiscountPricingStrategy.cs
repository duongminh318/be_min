using Lession11.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11
{
    public class DiscountPricingStrategy : IPricingStrategy
    {
        public decimal CalculatePrice(IRoom room, bool includesBreakfast, bool includesWiFi)
        {
            decimal price = room.BasePrice * 0.9m;
            if (includesWiFi) { price += 20m; }
            if (includesBreakfast) { price += 10; }
            return price;
        }
    }
}
