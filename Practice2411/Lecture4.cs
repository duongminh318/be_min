using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession4
{
    public class Lecture4
    {
        public static void Main() 
        {
            int i, n;       
            double s = 0.0; 

            Console.Write("\n\n");  
            Console.Write("Calculate the harmonic series and their sum:\n"); 
            Console.Write("----------------------------------------------"); 
            Console.Write("\n\n");

            Console.Write("Input the number of terms : "); 
            n = Convert.ToInt32(Console.ReadLine());    

            Console.Write("\n\n");

            // Loop to display and calculate the sum of the harmonic series
            for (i = 1; i <= n; i++)
            {
                Console.Write("1/{0} + ", i);  // Displaying the term of the harmonic series
                s += 1 / (float)i;  // Calculating and adding the current term to the sum
            }

            Console.Write("\nSum of Series upto {0} terms : {1} \n", n, s);  // Displaying the sum of the series
        }
    }
}
