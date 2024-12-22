using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession8;

public class FuncDelegate
{
    static void Main(string[] args)
    {
        // Func: Delegate có kiểu trả về
        // cú pháp theo dang lambda expresstion
        Func<int, int, int> add = (a, b) => a + b;
        Func<int> getRandomNumber1 = () => new Random().Next(1, 100);
        Console.WriteLine($"Sum:{add(10, 40)}");
        Console.WriteLine($"getRandomNumber1:{getRandomNumber1()}");


        Func<int , int ,int> getRandomNumber2 = delegate (int num1, int num2)
        {
            Random rnd = new Random();
            return rnd.Next(1, 100);
        };

        Console.WriteLine($"getRandomNumber2:{getRandomNumber2(1,2)}");

        // Acction: delegate ko có kiểu trả về: void
        Action<string> printMessage = message => Console.WriteLine(message);
        printMessage("Action delegate");

        // Predicate Delegate
        // Kiểm tra số chẵn, lẻ
        Predicate<int> isEven = x => x % 2 == 0;
        Console.WriteLine($"{isEven(6)}");  // true or false




    }
}
