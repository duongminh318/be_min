using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession6
{
    public class Homework3
    {
        public void Main()
        {
            // Danh sách đầu vào
            List<int> numbers = new List<int> { 3, 1, 4, 5, 2, 6 };

            Console.WriteLine("Danh sách ban đầu:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            // Sắp xếp theo yêu cầu
            CustomSort(numbers);

            Console.WriteLine("\n\nDanh sách sau khi sắp xếp:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        } 
        public void CustomSort(List<int> numbers)
        {
            // Sắp xếp danh sách với điều kiện đặc biệt
            numbers.Sort((a, b) =>
            {
                // Kiểm tra chẵn/lẻ
                bool isAEven = a % 2 == 0;
                bool isBEven = b % 2 == 0;

                if (isAEven && isBEven) // Cả hai đều là số chẵn
                {
                    return a.CompareTo(b); // Sắp xếp tăng dần
                }
                else if (!isAEven && !isBEven) // Cả hai đều là số lẻ
                {
                    return b.CompareTo(a); // Sắp xếp giảm dần
                }
                else if (isAEven) // Số chẵn trước số lẻ
                {
                    return -1;
                }
                else // Số lẻ sau số chẵn
                {
                    return 1;
                }
            });
        }
    }

}
