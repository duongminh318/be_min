using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession11.Concrete
{
    public class StandardRoom : Room
    {
        public StandardRoom()
        {
            Name = "Standard Room";
            BasePrice = 100m;
        }
    }
}
