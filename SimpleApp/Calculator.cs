using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp
{
    public class Calculator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Nhập số thứ nhất:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập số thứ hai:");
            int num2 = int.Parse(Console.ReadLine());

            int sum = num1 + num2;
            Console.WriteLine($"Tổng của {num1} và {num2} là: {sum}");
        }
    }
}
