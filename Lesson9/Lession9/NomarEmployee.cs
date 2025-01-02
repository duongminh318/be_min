using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession9
{
    public class NomarEmployee : Employee
    {
        public NomarEmployee(string name, string address)
        {
            Name = name;
            Adrress = address;
        }

        public string Adrress { get; set; }

    }
}
