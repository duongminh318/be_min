using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_test
{
    public class EX2
    {
        // Hàm tìm các cặp phần tử có tổng bằng giá trị k
        public static List<Tuple<int, int>> FindPairsWithSum(int[] array, int k)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            HashSet<int> seen = new HashSet<int>();

            foreach (int num in array)
            {
                int complement = k - num;

                if (seen.Contains(complement))
                {
                    result.Add(new Tuple<int, int>(complement, num));
                }

                seen.Add(num);
            }

            return result;
        }
    }
}
