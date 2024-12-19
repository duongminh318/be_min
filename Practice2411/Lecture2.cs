using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession4
{
    public class Lecture2
    {
        public static void Main()  
        {
            int i, j, rows;  

            Console.Write("\n\n");  // Displaying new lines
            Console.Write("Display the pattern like a right-angle triangle which repeats a number in a row:\n");  
            Console.Write("-------------------------------------------------------------------------------");  
            Console.Write("\n\n");

            Console.Write("Input number of rows : ");  
            rows = Convert.ToInt32(Console.ReadLine());

            for (i = 1; i <= rows; i++)  // Loop to iterate through each row
            {
                for (j = 1; j <= i; j++)  // Loop to print the value of 'i' in each row 'i' times
                {
                    Console.Write("{0}", i);  // Displaying 'i' to form the pattern
                }
                Console.Write("\n");  // Moving to the next line to form the right-angled pattern
            }
        }
    }
}
