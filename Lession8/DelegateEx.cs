using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession8
{
    public class DelegateEx
    {
        // Delegate in c#
        // định nghĩa về delegate
        // Delegate sẽ cho phép truyền và gọi các hàm như một đối tượng
        // Mục đích : Xây dựng ứng dụng linh hoạt và dễ scale
        // danh sách tham số truyền vào delegate phải trùng vs danh sách tham số của hàm sử dụng cho  deletgate
        // Single delegate
        public delegate void DisplayMessage(string message);

        // định nghĩa ra hàm cho delegate sử dụng
        public static void DoWork(DisplayMessage callback)
        {
            // Logic 1
            Console.WriteLine($"Proccesing.........");
            // Mô phỏng thực hiện 1 logic 2
            Thread.Sleep(4000);  // chúng ta đang xử lý 1 logic gì đây
            // callback => thực hiện 1 delegate
            callback("Work is Done");

        }
        static void Main(string[] args)
        {
            // khới tạo delegate và trỏ tới hàm showMessage
            //DisplayMessage del = new DisplayMessage(ShowMessage);

            //// thực thi delegate
            //del("Hello world 1");

            //// C2
            //DisplayMessage del2 = ShowMessage;
            //del2("Hello world 2");
            DoWork(result => Console.WriteLine(result));

        }
    }
}
