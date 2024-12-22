
using Lession8;


// Instance1 của của đối tượng student
// Khai báo ra 1 đối tượng (đăng ký vùng nhớ)
Student student1 = new Student(1, "Nguyễn Văn A", 10, DateTime.Now);



Student student2 = new Student(2, "Nguyễn Văn B", 10, DateTime.Now);

Student student3 = new Student(3, "Nguyễn Văn C");
student3.BirthDay = DateTime.Now;
student3.Age = 30;


var sum = StaticExam.Sum();