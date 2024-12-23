using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_test
{
    public class EX3
    {
      
        // Hàm sắp xếp nổi bọt (Bubble Sort)
        public static void BubbleSort(int[] array)
        {
            int n = array.Length; // Lấy chiều dài của mảng

            // Lặp qua từng phần tử trong mảng
            for (int i = 0; i < n - 1; i++)
            {
                // Lặp qua các phần tử chưa được sắp xếp
                for (int j = 0; j < n - i - 1; j++)
                {
                    // So sánh hai phần tử liền kề
                    if (array[j] > array[j + 1])
                    {
                        // Hoán đổi vị trí nếu phần tử trước lớn hơn phần tử sau
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Hàm tìm kiếm nhị phân (Binary Search)
        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;                // Chỉ số bên trái
            int right = array.Length - 1; // Chỉ số bên phải

            // Lặp khi khoảng tìm kiếm còn hợp lệ
            while (left <= right)
            {
                // Tính chỉ số giữa
                int mid = left + (right - left) / 2;

                // Kiểm tra nếu phần tử ở giữa là giá trị cần tìm
                if (array[mid] == target)
                    return mid; // Trả về chỉ số của phần tử tìm thấy

                // Nếu giá trị ở giữa nhỏ hơn giá trị cần tìm
                if (array[mid] < target)
                    left = mid + 1; // Dịch giới hạn trái sang phải
                else
                    right = mid - 1; // Dịch giới hạn phải sang trái
            }

            return -1; // Trả về -1 nếu không tìm thấy
        }
    }
}
