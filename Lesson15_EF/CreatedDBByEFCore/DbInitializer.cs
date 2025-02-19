using CreatedDBByEFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = CreatedDBByEFCore.Entities.Attribute;
//using Attribute = Attribute;

namespace CreatedDBByEFCore
{
    public static class DbInitializer
    {
        // Phương thức chính để khởi tạo dữ liệu ban đầu cho database
        public static void Initialize()
        {
            Console.WriteLine("Database seeded start");  // Log khi bắt đầu seed data
            CreateProduct();     // Tạo dữ liệu cho bảng Product
            CreateAttribute();   // Tạo dữ liệu cho bảng AttributeType
            CreateAttributeType(); // Tạo dữ liệu cho bảng Attribute
            Console.WriteLine("Database seeded successfully"); // Log khi hoàn thành
        }

        // Phương thức để thêm dữ liệu vào bảng Product
        public static void CreateProduct()
        {
            using (var context = new EcommerceDbContext()) // Tạo một DbContext mới
            {
                // Kiểm tra xem bảng Products đã có dữ liệu hay chưa
                if (!context.Products.Any())
                {
                    // Tạo một sản phẩm mới
                    var pro = new Product
                    {
                        Name = "Quần Jean - hàng cao cấp",
                        BasePrice = 560000,
                        Description = "Hàng cao cấp xuất khẩu đi USA",
                    };
                    context.Products.Add(pro); // Thêm sản phẩm vào database

                    // Thêm nhiều sản phẩm cùng lúc
                    context.Products.AddRangeAsync(
                       new Product { Name = "Giầy nữ", BasePrice = 230000 },
                       new Product { Name = "Áo vest", BasePrice = 450000 });

                    context.SaveChanges(); // Lưu thay đổi vào database
                }
            }
        }

        // Phương thức để thêm dữ liệu vào bảng AttributeType
        public static void CreateAttribute()
        {
            using (var context2 = new EcommerceDbContext()) // Tạo một DbContext mới
            {
                // Kiểm tra xem bảng AttributeTypes đã có dữ liệu chưa
                if (!context2.AttributeTypes.Any())
                {
                    // Thêm các loại thuộc tính vào database
                    context2.AttributeTypes.AddRange(
                        new AttributeType { Name = "Color" },
                        new AttributeType { Name = "Size" },
                        new AttributeType { Name = "Material" });

                    context2.SaveChanges(); // Lưu thay đổi vào database
                }
            }
        }

        // Phương thức để thêm dữ liệu vào bảng Attribute (giá trị của thuộc tính)
        public static void CreateAttributeType()
        {
            using (var context3 = new EcommerceDbContext()) // Tạo một DbContext mới
            {
                // Kiểm tra xem bảng Attributes đã có dữ liệu chưa
                if (!context3.Attributes.Any())
                {
                    // Lấy ID của các AttributeType từ database dựa vào tên
                    var id1 = context3.AttributeTypes.Where(x => x.Name == "Color").FirstOrDefault().Id;
                    var id2 = context3.AttributeTypes.Where(x => x.Name == "Size").FirstOrDefault().Id;
                    var id3 = context3.AttributeTypes.Where(x => x.Name == "Material").FirstOrDefault().Id;

                    // Thêm các giá trị thuộc tính vào database
                    context3.Attributes.AddRange(
                        new Attribute { AttributeValue = "Red", AttributeTypeId = id1 },
                        new Attribute { AttributeValue = "Blue", AttributeTypeId = id1 },
                        new Attribute { AttributeValue = "Small", AttributeTypeId = id2 },
                        new Attribute { AttributeValue = "Medium", AttributeTypeId = id2 },
                        new Attribute { AttributeValue = "Cotton", AttributeTypeId = id3 },
                        new Attribute { AttributeValue = "Denim", AttributeTypeId = id3 });

                    context3.SaveChanges(); // Lưu thay đổi vào database
                }
            }
        }
    }

}
