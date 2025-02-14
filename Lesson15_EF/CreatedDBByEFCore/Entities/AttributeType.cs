using CreatedDBByEFCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDatabaseByEFCore.Entities
{
    public class AttributeType : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        #region Relationship
        public ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();

        #endregion
    }
}
