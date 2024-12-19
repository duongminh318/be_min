/*
 * Các cách cộng chuỗi 
 */
// Cách 1: sử dụng toán tử cộng. mỗi lần công chuỗi thì chuỗi mới đc tạo ra và làm tăng cái số lượng bộ nhớ đc cấp phát
// Hiệu năng kém khi cộng nhiều chuỗi trong 1 vòng lặp
// Sử dụng tốt nhất: khi số lượng chuỗi nhỏ và ko lặp đi lặp lại

//string result = "Hello" + " " + "world";

//// Cách 2: String.Concat
//// Hiệu năng tốt hơn vì Concat ko tạo ra biến trung gian
//// phù hơp với case khi cần nối 1 số chuỗi cố định
//// Sử dụng tốt nhất: nối chuỗi từ các biến hoặc những giá trị ko đổi
//string str1 = string.Concat("Hello", " ", "world", " 2411");

//// Cách 3: sử string builder
//// được thiết kế để tối ưu cho việc cộng nhiều chuỗi
//// sử dụng tốt nhất: cần cộng nhiều chuỗi trong vòng lặp hoặc xây dựng 1 chuỗi động phức tạp

//StringBuilder stringBuilder = new StringBuilder();
//stringBuilder.Append("Hello world");
//stringBuilder.Append("2411");
//Console.WriteLine(stringBuilder);

//// Cach 4: string.join
//// Hiệu năng của string.join tốt hơn cách 1 khi cần nối danh sách các chuỗi (Mảng, collection)
//// chỉ cần 1 lần xử lý để nối tất cả các chuỗi trong mảng, trách việc cấp phát nhiều lần vùng nhớ
//// sử dụng tốt nhất: khi nối chuỗi (mảng, collection) với các ký tự phân cách
//string str2 = string.Join(" ", new[] { "Hello", "wold" });

//// Cách 5: Interpolation ($"chuoi")
////sử dụng tốt nhất: cần tạo ra 1 chuỗi dễ đọc và các giá trị truyền động vào
//string str3 = $"Phạm thành công {str1} {result}";
//string.Format(str1, str2, str3);   


using Lession5;

DateTime date = DateTime.Now.AddDays(-3); // thời gian hiện tại
Console.WriteLine(DateTime.Today.ToString());

// convert datetime to string
Console.WriteLine(date.ToString("dd/MM/yyyy hh:mm"));

// convert string to datetime

// Tuple

Tuple<int, string, string> person = new Tuple<int, string, string>(1, "Steve", "Jobs");

Console.WriteLine(person.Item1);
Console.WriteLine(person.Item2);
Console.WriteLine(person.Item3);

var person1 = Tuple.Create(1, "Steve", "Jobs");

(int, string, string) person2 = (1, "Bill", "Gates");

var tu = new TuppleEx();
var tu1 = tu.TupleExam();

Console.WriteLine(tu1.id);
Console.WriteLine(tu1.Name);

// Genneric
DataStore<string> dataStore = new DataStore<string>();
dataStore.Data = "Lê thành công";
Console.WriteLine(dataStore.Data);

DataStore<int> dataStore1 = new DataStore<int>();
dataStore1.Data = 10;

DataStore<bool> dataStore2 = new DataStore<bool>();
dataStore2.Data = true;

DataStore2<int> dt2 = new DataStore2<int>();
dt2.AddOrUpdate(1, 1);
dt2.AddOrUpdate(2, 10);
dt2.AddOrUpdate(3, 20);
dt2.AddOrUpdate(4, 30);

Console.WriteLine(dt2.GetData(3));


/* ----------------------------List---------------------------------------------*/

var lst = new List<string>();
lst.Add("1");
lst.Add("2");
lst.Add("3");
lst.Add("3");
lst.Add("5");
lst.Add("3");
lst.Add("4");

lst.AddRange(new string[3] { "1", "2", "3" });

lst.RemoveAt(1);   // theo index
lst.Remove("3");
foreach (var item in lst)
    Console.WriteLine(item);