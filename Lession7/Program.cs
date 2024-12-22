//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//// IEnumable
//IEnumerable<int> values = new List<int>() { 1,2 ,3,4, 5 };
//// duyệt qua các phần tử
//foreach (int value in values)
//{
//    Console.WriteLine(value);
//}    

//ICollectiom
using Lession7;
using System.Collections;

ICollection<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
numbers.Add(6);


// List
IList<int> numbers2 = numbers.ToList();

//numbers2.Insert(10, 6);

//numbers2.RemoveAt(15);

int[] numberInt = new int[3] { 1, 23, 4 };
// Array list
ArrayList arrayList = new ArrayList();
arrayList.Add(1);
arrayList.Add("Hello worl");
arrayList.AddRange(numberInt);

var isExists = arrayList.Contains(1);

// Dictionary

Dictionary<string, string> studentDic = new Dictionary<string, string>();
// Add element
studentDic.Add("1", "Nguyễn Văn A");
studentDic.Add("2", "Nguyễn Văn B");
studentDic.Add("3", "Nguyễn Văn C");

// Kiểm tra khoá hoặc giá trị
bool existsKey = studentDic.ContainsKey("1");
bool existsValue = studentDic.ContainsValue("Nguyễn Văn A1");

Console.WriteLine(existsKey);
Console.WriteLine(existsValue);

// Remove element
studentDic.Remove("1");

// update element
studentDic["2"] = "Nguyen Van B1";

// get keys or values
var keys = studentDic.Keys;
var values = studentDic.Values;

// duyet cac phan tu cuar dic

foreach (KeyValuePair<string, string> item in studentDic)
{
    Console.WriteLine($"Key: {item.Key} --  Value {item.Value}");
}

foreach (var item in studentDic)
{
    Console.WriteLine($"Key: {item.Key} --  Value {item.Value}");
}

foreach (var item in studentDic.Keys)
{
    Console.WriteLine(item);
}

foreach (var item in studentDic.Values)
{
    Console.WriteLine(item);
}

// Extension method
var input = "viet Nam muon nam";
Console.WriteLine(input.ToUpperCaseFirstLetter(true));







