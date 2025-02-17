using CreateDatabaseByEFCore;
using CreateDatabaseByEFCore.Entities;
using CreatedDBByEFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = CreateDatabaseByEFCore.Entities.Attribute;

namespace CreatedDBByEFCore
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            using (var context = new EcommerceDbContext())
            {
                //db.Database.EnsureCreated();
                // Look for any products.
                if (!context.Products.Any())
                {
                    var products = new Product[]
                  {
                    new Product { Name = "Giày nữ", BasePrice = 1000000 },
                    new Product { Name = "Áo vest", BasePrice = 2000000 },
                    new Product { Name = "Product 3", BasePrice = 3000000 },
                    new Product { Name = "Product 4", BasePrice = 4000000 },
                    new Product { Name = "Product 5", BasePrice = 5000000 },
                  };
                    foreach (Product p in products)
                    {
                        context.Products.Add(p);
                    }
                    context.SaveChangesAsync();
                    Console.WriteLine("Success");
                }


                // Kiểm tra xem bảng AttributeTypes có dữ liệu hay chưa
                if (!context.AttributeTypes.Any())
                {
                    // Thêm dữ liệu mẫu vào bảng AttributeTypes
                    context.AttributeTypes.AddRange(new List<AttributeType>
                    {
                        new AttributeType { Name = "Color" },
                        new AttributeType { Name = "Size" },
                        new AttributeType { Name = "Material" }
                    });

                    // Lưu thay đổi vào database
                     context.SaveChangesAsync();
                    Console.WriteLine("Database seeded successfully.");
                }
                else
                {
                    Console.WriteLine("Database already has data.");
                }



                /*   var variants = new Variant[]
                   {
                       new Variant { Name = "Variant 1", ProductId = 1 },
                       new Variant { Name = "Variant 2", ProductId = 2 },
                       new Variant { Name = "Variant 3", ProductId = 3 },
                       new Variant { Name = "Variant 4", ProductId = 4 },
                       new Variant { Name = "Variant 5", ProductId = 5 },
                   };
                   foreach (Variant v in variants)
                   {
                       db.Variants.Add(v);
                   }
                   db.SaveChanges();
                   var attributeTypes = new AttributeType[]
                   {
                       new AttributeType { Name = "Color" },
                       new AttributeType { Name = "Size" },
                       new AttributeType { Name = "Weight" },
                       new AttributeType { Name = "Material" },
                       new AttributeType { Name = "Origin" },
                   };
                   foreach (AttributeType at in attributeTypes)
                   {
                       db.AttributeTypes.Add(at);
                   }
                   db.SaveChanges();
                   var attributes = new Attribute[]
                   {
                       new Attribute { AttributeTypeId = 1, AttributeValue = "Red" },
                       new Attribute { AttributeTypeId = 1, AttributeValue = "Blue" },
                       new Attribute { AttributeTypeId = 1, AttributeValue = "Green" },
                       new Attribute { AttributeTypeId = 2, AttributeValue = "S" },
                       new Attribute { AttributeTypeId = 2, AttributeValue = "M" },
                       new Attribute { AttributeTypeId = 2, AttributeValue = "L" },
                   };*/
            }
        }
    }
}
