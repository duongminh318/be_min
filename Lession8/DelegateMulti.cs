using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession8
{
    public class DelegateMulti
    {
        public delegate void Notify(string mess);

        public static void Method1(string mess)
        {
            Console.WriteLine($"Method1: {mess} ");
        }

        public static void Method2(string mess)
        {
            Console.WriteLine($"Method2: {mess} ");
        }

        static void Main(string[] args)
        {
            Notify notify = Method1;
            notify += Method2;

            // Gọi delegate
            notify("Hello Multi- delegate");

            // Loại bỏ 1 phương thức đính kèm  trong delegate

            notify -= Method1;
            notify("Remove method1");

        }
    }
}
