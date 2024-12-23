using practical_test;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Hàm dùng chung cho nhập mảng
int[] InputArray()
{
    Console.WriteLine("Nhập các số nguyên, cách nhau bằng khoảng trắng:");
    string input = Console.ReadLine();
    string[] inputs = input.Split(' ');
    return Array.ConvertAll(inputs, int.Parse);
}

// Hàm dùng chung để in mảng
void PrintArray(int[] array)
{
    Console.WriteLine(string.Join(" ", array));
}

// Hàm main logic
void RunEX1()
{
    int[] array = InputArray();
    Dictionary<int, int> result = EX1.CountFrequency(array);

    Console.WriteLine("Số lần xuất hiện của các phần tử:");
    foreach (var item in result)
    {
        Console.WriteLine($"Phần tử {item.Key} xuất hiện {item.Value} lần.");
    }
}

void RunEX2()
{
    int[] array = InputArray();
    Console.WriteLine("Nhập giá trị k:");
    int k = int.Parse(Console.ReadLine());

    List<Tuple<int, int>> pairs = EX2.FindPairsWithSum(array, k);

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
}

void RunEX3()
{
    int[] array = InputArray();
    EX3.BubbleSort(array);
    Console.WriteLine("Mảng sau khi sắp xếp:");
    PrintArray(array);

    Console.WriteLine("Nhập số cần tìm:");
    int target = int.Parse(Console.ReadLine());

    int index = EX3.BinarySearch(array, target);

    if (index != -1)
    {
        Console.WriteLine($"Số {target} được tìm thấy ở vị trí {index} (chỉ số bắt đầu từ 0).");
    }
    else
    {
        Console.WriteLine($"Không tìm thấy số {target} trong mảng.");
    }
}

// Chạy bài tập tùy chọn
Console.WriteLine("Mời thím chọn bài tập để chạy (1, 2, 3):");
int choice = int.Parse(Console.ReadLine());

switch (choice)
{
    case 1:
        RunEX1();
        break;
    case 2:
        RunEX2();
        break;
    case 3:
        RunEX3();
        break;
    default:
        Console.WriteLine("Lựa chọn không hợp lệ.");
        break;
}
