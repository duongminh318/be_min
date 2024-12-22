// See https://aka.ms/new-console-template for more information
using practical_test;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
/*gọi EX1*/

/*Console.WriteLine("Hello, World!");
// Nhập mảng từ người dùng
Console.WriteLine("Nhập các số nguyên, cách nhau bằng khoảng trắng:");
string input = Console.ReadLine();

// Tách các số từ chuỗi nhập vào
string[] inputs = input.Split(' ');
int[] array = Array.ConvertAll(inputs, int.Parse);

// Gọi hàm CountFrequency từ class EX1
Dictionary<int, int> result = EX1.CountFrequency(array);

// In ra kết quả
Console.WriteLine("Số lần xuất hiện của các phần tử:");
foreach (var item in result)
{
    Console.WriteLine($"Phần tử {item.Key} xuất hiện {item.Value} lần.");
}
*/

/*Gọi EX2*/
/*
// Nhập mảng từ người dùng
Console.WriteLine("Nhập các số nguyên, cách nhau bằng khoảng trắng:");
string input = Console.ReadLine();

// Tách các số từ chuỗi nhập vào
string[] inputs = input.Split(' ');
int[] array = Array.ConvertAll(inputs, int.Parse);

// Nhập giá trị k
Console.WriteLine("Nhập giá trị k:");
int k = int.Parse(Console.ReadLine());

// Gọi hàm FindPairsWithSum từ class EX2
List<Tuple<int, int>> pairs = EX2.FindPairsWithSum(array, k);

// In ra kết quả
if (pairs.Count > 0)
{
    Console.WriteLine($"Các cặp phần tử có tổng bằng {k} là:");
    foreach (var pair in pairs)
    {
        Console.WriteLine($"({pair.Item1}, {pair.Item2})");
    }
}
else
{
    Console.WriteLine($"Không tìm thấy cặp phần tử nào có tổng bằng {k}.");
}
*/
/*Goi EX3*/

// Nhập mảng từ người dùng
Console.WriteLine("Nhập các số nguyên, cách nhau bằng khoảng trắng:");
string input = Console.ReadLine();
string[] inputs = input.Split(' ');
int[] array = Array.ConvertAll(inputs, int.Parse);

// Sắp xếp mảng
EX3.BubbleSort(array);
Console.WriteLine("Mảng sau khi sắp xếp:");
Console.WriteLine(string.Join(" ", array));

// Nhập số cần tìm kiếm
Console.WriteLine("Nhập số cần tìm:");
int target = int.Parse(Console.ReadLine());

// Tìm kiếm nhị phân
int index = EX3.BinarySearch(array, target);

// In kết quả
if (index != -1)
{
    Console.WriteLine($"Số {target} được tìm thấy ở vị trí {index} (chỉ số bắt đầu từ 0).");
}
else
{
    Console.WriteLine($"Không tìm thấy số {target} trong mảng.");
}
        

