using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatedDBByEFCore.Entities
{
    public class VariantAttribute
    {
        public Guid VariantId { get; set; }
        public Guid AttributeId { get; set; }

        // Navigation Properties
        public Variant? Variant { get; set; }
        public CreateDatabaseByEFCore.Entities.Attribute? Attribute { get; set; } // Chỉ rõ namespace
    }
}
