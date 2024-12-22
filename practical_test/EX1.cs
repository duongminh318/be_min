using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_test
{
    /*Bài tập 1: Đếm số lần xuất hiện của các phần tử trong mảng

    Mục tiêu: Sử dụng collection (Dictionary) để lưu trữ và đếm tần suất xuất hiện của các phần tử trong mảng.

    Đề bài:

    Viết chương trình C# nhận vào một mảng số nguyên từ người dùng. Sau đó, chương trình sẽ:

    Đếm số lần xuất hiện của mỗi phần tử trong mảng.

    In ra kết quả theo định dạng: phần tử kèm theo số lần xuất hiện của nó.

    Yêu cầu:

    Sử dụng Dictionary<int, int> để lưu trữ phần tử và số lần xuất hiện của nó.

    Nếu phần tử đã tồn tại trong từ điển, tăng giá trị đếm lên*/
    public class EX1
    {
        // Hàm đếm số lần xuất hiện của các phần tử trong mảng
        public static Dictionary<int, int> CountFrequency(int[] array)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach (int num in array)
            {
                if (frequency.ContainsKey(num))
                {
                    frequency[num]++;
                }
                else
                {
                    frequency[num] = 1;
                }
            }

            return frequency;
        }
    }
}
