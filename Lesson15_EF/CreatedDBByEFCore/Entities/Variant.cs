using CreateDatabaseByEFCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatedDBByEFCore.Entities
{
    public class Variant : EntityBase
    {
        [Required]
        public Guid ProductId { get; set; }  // Khóa ngoại

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a positive number")]
        public int NumberInStock { get; set; } = 0;

        // Navigation Property
        public Product? Product { get; set; }

        // Liên kết với VariantAttributes
        public ICollection<VariantAttribute> VariantAttributes { get; set; } = new List<VariantAttribute>();
    }
}
