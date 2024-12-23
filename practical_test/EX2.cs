using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_test
{
    public class EX2
    {
        // Hàm tìm các cặp phần tử trong mảng có tổng bằng giá trị k
        public static List<Tuple<int, int>> FindPairsWithSum(int[] array, int k)
        {
            // Danh sách để lưu kết quả các cặp phần tử
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            // Tập hợp để lưu các phần tử đã được duyệt
            HashSet<int> seen = new HashSet<int>();

            // Duyệt qua từng phần tử trong mảng
            foreach (int num in array)
            {
                // Tìm phần tử còn lại để tổng bằng k (gọi là "complement")
                int complement = k - num;

                // Kiểm tra nếu phần tử complement đã tồn tại trong tập "seen"
                if (seen.Contains(complement))
                {
                    // Nếu tồn tại, thêm cặp (complement, num) vào danh sách kết quả
                    result.Add(new Tuple<int, int>(complement, num));
                }

                // Thêm phần tử hiện tại vào tập "seen"
                seen.Add(num);
            }

            // Trả về danh sách các cặp phần tử
            return result;
        }
    }
}
