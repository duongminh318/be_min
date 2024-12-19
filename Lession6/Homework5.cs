using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession6
{
    public class Homework5
    {
        static void Main()
        {
            // Mảng đầu vào và giá trị K
            int[] numbers = { 1, 5, 7, -1, 5 };
            int K = 6;

            Console.WriteLine($"Các cặp số có tổng bằng {K}:");
            FindPairsWithSum(numbers, K);
        }

        static void FindPairsWithSum(int[] numbers, int K)
        {
            int n = numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    // Kiểm tra nếu tổng của cặp số bằng K
                    if (numbers[i] + numbers[j] == K)
                    {
                        Console.WriteLine($"({numbers[i]}, {numbers[j]})");
                    }
                }
            }
        }
        static void FindPairsWithSumDic(int[] numbers, int K)
        {
            // Từ điển để lưu số lần xuất hiện của từng phần tử
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach (int num in numbers)
            {
                // Nếu tìm thấy cặp số, in ra
                int complement = K - num;
                if (frequency.ContainsKey(complement))
                {
                    for (int i = 0; i < frequency[complement]; i++)
                    {
                        Console.WriteLine($"({complement}, {num})");
                    }
                }

                // Thêm hoặc cập nhật số lần xuất hiện của phần tử hiện tại
                if (frequency.ContainsKey(num))
                    frequency[num]++;
                else
                    frequency[num] = 1;
            }
        }
    }
}
