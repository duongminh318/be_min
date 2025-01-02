using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession9
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        // Phương thức đa hình
        public virtual decimal CalculateSalary()
        {
            return (decimal)3.14 * 15000000;   // công thức tính lương cơ bản
        }
        public decimal ShowBankCard()
        {
            return (decimal)3.14 * 15000000;   // công thức tính lương cơ bản
        }

        public decimal ShowBankCard(string bankName)
        {
            if (bankName == "MB")
            {
                return 30;
            }
            else if (bankName == "VCB")
            {
                return 30;
            }
            else { return 50; }
        }
        public string ShowBankCard(string bankName, string bankCode)
        {
           return bankName;
        }

    }

    public partial class BoatExten
    {
        public string Age { get; set; }
    }
}
