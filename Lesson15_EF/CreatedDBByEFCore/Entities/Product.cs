using CreatedDBByEFCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace CreatedDBByEFCore.Entities;

public class Product : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "BasePrice must be a positive number")]
    public decimal BasePrice { get; set; }

    // Liên kết với Variant
    public ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
