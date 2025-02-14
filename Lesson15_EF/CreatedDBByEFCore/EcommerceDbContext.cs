
using CreateDatabaseByEFCore.Entities;
using CreatedDBByEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = CreateDatabaseByEFCore.Entities.Attribute;

namespace CreateDatabaseByEFCore
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<AttributeType> AttributeTypes { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<VariantAttribute> VariantAttributes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Kết nối đến SQL Server
            optionsBuilder.UseSqlServer("Server=MAYTINH;Database=EcommerceDatabase;User Id=sa;Password=dminh318;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Cấu hình thêm nếu cần (Mapping hoặc Fluent API)
            // modelBuilder.Entity<Entities.Attribute>().Property(d => d.Name).IsRequired().HasMaxLength(200);
            // modelBuilder.Entity<Entities.Attribute>().HasIndex(d => d.AttributeTypeId);
            //modelBuilder.Entity<Deal>().Property(d => d.NguoiBan).IsRequired().HasMaxLength(100);
            base.OnModelCreating(modelBuilder);

            // UNIQUE Index cho Product.Name
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            // UNIQUE Index cho Variant.Name (mỗi Product có một Variant với Name duy nhất)
            modelBuilder.Entity<Variant>()
                .HasIndex(v => new { v.Name, v.ProductId })
                .IsUnique();

            // UNIQUE Index cho AttributeType.Name
            modelBuilder.Entity<AttributeType>()
                .HasIndex(at => at.Name)
                .IsUnique();

            // UNIQUE Index cho Attribute.AttributeValue
            modelBuilder.Entity<Attribute>()
                .HasIndex(a => new { a.AttributeValue, a.AttributeTypeId })
                .IsUnique();

            // Cấu hình khóa chính cho bảng trung gian VariantAttributes
            modelBuilder.Entity<VariantAttribute>()
                .HasKey(va => new { va.VariantId, va.AttributeId });

            // Ràng buộc CHECK để đảm bảo giá trị Price và Stock >= 0
            modelBuilder.Entity<Product>()
                .ToTable(t => t.HasCheckConstraint("CHK_Product_BasePrice", "[BasePrice] >= 0"));

            modelBuilder.Entity<Variant>()
                .ToTable(t => t.HasCheckConstraint("CHK_Variant_Price", "[Price] >= 0"))
                .ToTable(t => t.HasCheckConstraint("CHK_Variant_Stock", "[NumberInStock] >= 0"));
        }
    }
}
