using CreatedDBByEFCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabaseByEFCore.Entities
{
    public class Attribute : EntityBase
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        // Liên kết với bảng AtrributeType (C1)
        public Guid AttributeTypeId { get; set; }
        public AttributeType AttributeType { get; set; }
    }
}
