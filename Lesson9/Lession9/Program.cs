using Lession9;

// đa hình qua class kế thừa
Employee manager = new Manager(45000000, "Nguyễn Văn A", 20);
Employee developer = new Developer(12, 50, "Nguyễn Văn B");
Employee nomarl = new NomarEmployee("Nguyen Van C","Hà nội");

//// ko dc
//Manager mn = new Employee();

manager.ShowBankCard();
manager.ShowBankCard("MB");

// cùng 1 phương thức tính lương nhưng hành vi (cách ứng xử với cùng 1 thông điệp) khác nhau thì cho ra kq khác nhau
Console.WriteLine($"{manager.Name} Salary: {manager.CalculateSalary()}");
Console.WriteLine($"{developer.Name} Salary: {developer.CalculateSalary()}");
Console.WriteLine($"{nomarl.Name} Salary: {nomarl.CalculateSalary()}");


Vehicle car = new Car();
Vehicle air = new Plane();


car.ShowInfo();
car.Move();

air.ShowInfo();
air.Move();
IShape shape = new Rectangle();

var rectangle = new Rectangle
{
    Width = 30,
    Height = 40
};
rectangle.CalculateArea();
rectangle.CalculatePerimeter();
var area =  rectangle.DisplayArea();
Console.WriteLine("Dien tich: " + area);

var boat = new BoatExten();
boat.Name = "";
boat.Age = "1";


