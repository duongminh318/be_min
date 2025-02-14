using CreateDatabaseByEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabaseByEFCore
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeType> AttributeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Kết nối đến SQL Server
            optionsBuilder.UseSqlServer("Server=MAYTINH;Database=EcommerceDatabase;User Id=sa;Password=dminh318;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Cấu hình thêm nếu cần (Mapping hoặc Fluent API)
            modelBuilder.Entity<Entities.Attribute>().Property(d => d.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Entities.Attribute>().HasIndex(d => d.AttributeTypeId);
            //modelBuilder.Entity<Deal>().Property(d => d.NguoiBan).IsRequired().HasMaxLength(100);
        }
    }
}
