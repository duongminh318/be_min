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
            // Tạo một Dictionary để lưu cặp phần tử (key) và số lần xuất hiện (value)
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            // Duyệt qua từng phần tử trong mảng
            foreach (int num in array)
            {
                // Kiểm tra xem phần tử hiện tại đã tồn tại trong từ điển chưa
                if (frequency.ContainsKey(num))
                {
                    // Nếu tồn tại, tăng số lần xuất hiện thêm 1
                    frequency[num]++;
                }
                else
                {
                    // Nếu chưa tồn tại, thêm phần tử vào từ điển với giá trị ban đầu là 1
                    frequency[num] = 1;
                }
            }

            // Trả về từ điển chứa kết quả đếm số lần xuất hiện
            return frequency;
        }
    }
}
