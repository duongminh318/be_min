using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession4
{
    public class Lecture3
    {
        public static void Main()  
        {
            int i, j, spc, rows, k;  

            Console.Write("\n\n");  
            Console.Write("Display the pattern like a pyramid with asterisk:\n");  
            Console.Write("-------------------------------------------------"); 
            Console.Write("\n\n");

            Console.Write("Input number of rows : ");  
            rows = Convert.ToInt32(Console.ReadLine());

            spc = rows + 4 - 1;  // Calculating the initial count of spaces for proper alignment

            for (i = 1; i <= rows; i++)  // Loop to iterate through each row
            {
                for (k = spc; k >= 1; k--)  // Loop to print spaces before the asterisks for the pyramid pattern
                {
                    Console.Write(" ");  // Displaying spaces
                }

                for (j = 1; j <= i; j++)  // Loop to print asterisks in each row 'i' times
                {
                    Console.Write("* ");  // Displaying an asterisk and a space
                }
                Console.Write("\n");  // Moving to the next line to form the pyramid pattern
                spc--;  // Decreasing the space count for the next row
            }
        }
    }
}
