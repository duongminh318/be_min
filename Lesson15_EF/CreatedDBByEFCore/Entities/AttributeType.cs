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
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        #region Relationship
        public ICollection<Attribute> Attributes { get; set; }

        #endregion
    }
}
