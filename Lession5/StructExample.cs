namespace Lession5;

/*
 Quản lý lịch họp (Meeting Management)
Tạo struct Meeting với các thuộc tính:
    MeetingId (kiểu Guid),
    Title (tên buổi họp),
    StartTime (kiểu DateTime),
    EndTime (kiểu DateTime),
    Participants (danh sách các email tham gia).
Viết chương trình:
Nhập thông tin cho 5 buổi họp.
Hiển thị danh sách các buổi họp, sắp xếp theo thời gian bắt đầu.
Kiểm tra xem một thời gian nhất định có bị trùng với bất kỳ buổi họp nào không. nếu trùng 
thì hiển thị thông tin ra màn hình
 */

struct Student
{
    // Các trường dữ liệu (thuộc tính)  lưu trữ thông tin của sinh viên
    public int Id;
    public Guid MeetingId;
    public string Name;
    public int Age;
   public Student(int id, string name, int age, Guid meetingId)
    {
        Id = id;
        Name = name;    
        Age = age;
        MeetingId = meetingId;
    }


    // Phương thức (method) -- giải quyết các nghiệp vụ của phần (thuộc tính)  -behaviour
    public void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
    public void DisplayInfo111(string a, int ad)
    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
    }
    public Student SearchStudentById(int id)
    {
        return new Student { Id = id};
    }
}
