using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession6
{
    public class Homework2
    {
        public void OrderByForLength()
        {
            // Danh sách các chuỗi
            List<string> words = new List<string> { "apple", "banana", "kiwi", "pear", "mango" };

            Console.WriteLine("Danh sách ban đầu:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            // Sắp xếp chuỗi theo độ dài và sau đó theo thứ tự từ điển nếu độ dài bằng nhau
            var sortedWords = words.OrderBy(word => word.Length).ThenBy(word => word).ToList();

            Console.WriteLine("\nDanh sách sau khi sắp xếp:");
            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }

        }
        public void OrderByForLength2()
        {
            List<string> words = new List<string> { "apple", "banana", "kiwi", "pear", "mango" };

            Console.WriteLine("Danh sách ban đầu:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            // Sắp xếp danh sách theo độ dài và từ điển
            BubbleSort(words);

            Console.WriteLine("\nDanh sách sau khi sắp xếp:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        public void BubbleSort(List<string> words)
        {
            int n = words.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // So sánh độ dài
                    if (words[j].Length > words[j + 1].Length ||
                        (words[j].Length == words[j + 1].Length && string.Compare(words[j], words[j + 1]) > 0))
                    {
                        // Hoán đổi nếu cần
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }
        }

    }

}
