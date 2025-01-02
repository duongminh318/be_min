using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession9
{
    public class Manager : Employee
    {
        private decimal Bonus { get; set; }
        public Manager(decimal bonus, string name, int age) 
        {
            this.Bonus = bonus;
            this.Name = name;
            this.Age = age;
        }

        // Ghi đè phương thức tính lương OCP (opne/closed principle)
        public override decimal CalculateSalary()
        {
            var basic =  base.CalculateSalary();
            return basic + Bonus;
        }
    }
}
