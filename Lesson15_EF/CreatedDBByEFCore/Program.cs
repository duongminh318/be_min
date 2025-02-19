// See https://aka.ms/new-console-template for more information
using CreatedDBByEFCore;
using Microsoft.EntityFrameworkCore;
using System.Text;

/*Console.WriteLine("Seeding Data Loading___");

try
{
    // Tạo một thể hiện của `EcommerceDbContext` để làm việc với database
    using var context = new EcommerceDbContext();

    // Thực hiện migration: nếu database chưa có hoặc chưa cập nhật schema mới nhất, EF Core sẽ cập nhật
    context.Database.Migrate();

    // Thông báo thành công sau khi khởi tạo database
    Console.WriteLine("Initialize DB success");

    // Gọi phương thức `Initialize()` từ `DbInitializer` để seed dữ liệu vào database nếu cần
    DbInitializer.Initialize();
}
catch (Exception ex)
{
    // Nếu có lỗi xảy ra trong quá trình kết nối hoặc migrate database, in ra thông báo lỗi
    Console.WriteLine($"Error: {ex.Message}");

    // In thêm stack trace để dễ dàng debug khi gặp lỗi
    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
}*/


// Truy vấn dữ liệu sử dụng Linq
Console.OutputEncoding = Encoding.UTF8;
DBQuery.FilterDatabase();
