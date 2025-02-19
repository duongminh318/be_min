using CreatedDBByEFCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatedDBByEFCore.Entities
{
    public class Attribute : EntityBase
    {
        
        [Required]
        public Guid AttributeTypeId { get; set; }  // Khóa ngoại

        [Required]
        [MaxLength(50)]
        public string AttributeValue { get; set; } = string.Empty;

        // Navigation Property
        public AttributeType? AttributeType { get; set; }

        // Liên kết với VariantAttributes
        public ICollection<VariantAttribute> VariantAttributes { get; set; } = new List<VariantAttribute>();
    }
}
