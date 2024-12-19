
namespace Lession4;

/*
 Bài 1: Viết chương trình bằng C# Sharp để hiển thị một mẫu như hình tam giác vuông có số
    Output: 
        1
        12
        123
        1234
 */
public class Lecture1
{
    public static void Main() 
    {
        int i, j, rows; 

        Console.Write("\n\n");  // Displaying new lines
        Console.Write("Display the pattern as a right-angle triangle using numbers:\n"); 
        Console.Write("-----------------------------------------------------------");  
        Console.Write("\n\n");

        Console.Write("Input number of rows : "); 
        rows = Convert.ToInt32(Console.ReadLine()); 

        for (i = 1; i <= rows; i++)  // Loop to iterate through each row
        {
            for (j = 1; j <= i; j++)  // Loop to print numbers in each row from 1 to 'i'
            {
                Console.Write("{0}", j);  // Displaying numbers to form the pattern
            }
            Console.Write("\n");  // Moving to the next line to form the right-angled pattern
        }
    }
}
