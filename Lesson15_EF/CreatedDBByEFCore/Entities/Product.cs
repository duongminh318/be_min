using CreatedDBByEFCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace CreateDatabaseByEFCore.Entities;

public class Product : EntityBase
{
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    [MaxLength(1000)]
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
}
