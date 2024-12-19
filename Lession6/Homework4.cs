using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession6
{
    public class Homework4
    {
        public void Main()
        {
            // Dãy số với một số bị mất
            int[] numbers = { 1, 2, 4, 5, 6 }; // Ví dụ: mất số 3

            // Tìm giá trị bị mất
            int missingNumber = FindMissingNumber(numbers);

            Console.WriteLine("Số bị mất là: " + missingNumber);
        }

        static int FindMissingNumber(int[] numbers)
        {
            // Tìm số lớn nhất n
            int n = numbers.Length + 1;

            // Tính tổng dự kiến (từ 1 đến n)
            int expectedSum = n * (n + 1) / 2;

            // Tính tổng thực tế của mảng
            int actualSum = 0;
            foreach (int num in numbers)
            {
                actualSum += num;
            }

            // Số bị mất = Tổng dự kiến - Tổng thực tế
            return expectedSum - actualSum;
        }
    }
}
