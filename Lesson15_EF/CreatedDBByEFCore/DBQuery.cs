using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatedDBByEFCore
{
    public static class DBQuery
    {
        public static void FilterDatabase()
        {
            // Khởi tạo DbContext để làm việc với database
            using (var context = new EcommerceDbContext())
            {
                // ✅ Cách 1: Query Syntax (sử dụng LINQ truy vấn giống SQL)
                // Lấy ra danh sách sản phẩm có giá (BasePrice) lớn hơn 300,000 và sắp xếp tăng dần theo giá
                var products1 = (from p in context.Products
                                 where p.BasePrice > 300000
                                 orderby p.BasePrice ascending
                                 select new ProductDto
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     BasePrice = p.BasePrice,
                                 }).ToList();

                // In danh sách sản phẩm thỏa điều kiện (Query Syntax)
                foreach (var item in products1)
                {
                    Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, BasePrice: {item.BasePrice}");
                }

                // ✅ Cách 2: Method Syntax (Lambda Expression)
                // Lấy danh sách sản phẩm có BasePrice > 300,000 và sắp xếp giảm dần theo giá
                var product2 = context.Products
                    .Where(x => x.BasePrice > 300000)   // Lọc sản phẩm có giá > 300,000
                    .OrderByDescending(x => x.BasePrice) // Sắp xếp giảm dần theo giá
                    .Select(x => new ProductDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        BasePrice = x.BasePrice,
                    })
                    .ToList();

                // ✅ Lấy một sản phẩm đầu tiên có giá bằng 20,000
                var product3 = context.Products.FirstOrDefault(x => x.BasePrice == 20000);
                if (product3 != null)
                {
                    Console.WriteLine($"Id: {product3.Id}, Name: {product3.Name}, BasePrice: {product3.BasePrice}");
                }

                // ✅ Lấy duy nhất một sản phẩm có giá bằng 230,000
                // Nếu có nhiều hơn một sản phẩm thỏa điều kiện thì sẽ bị lỗi
                var product4 = context.Products.SingleOrDefault(x => x.BasePrice == 230000);
            }
        }
    }

    // Định nghĩa lớp ProductDto để chứa dữ liệu sản phẩm khi truy vấn
    public class ProductDto
    {
        public Guid Id { get; set; }         // ID của sản phẩm
        public string Name { get; set; }     // Tên sản phẩm
        public decimal BasePrice { get; set; } // Giá sản phẩm
    }

}
