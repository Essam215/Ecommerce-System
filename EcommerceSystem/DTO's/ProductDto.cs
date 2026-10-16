using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.DTO_s;
    public class GetProductDto
    {
    [Key]
    public int Id { get; set; }

    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Required, Range(0.01, 1000000)]
    public decimal Price { get; set; }
    [Required, Range(0, 1000000)]
    public int StockQuantity { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
}

public class CreateProductDto
{
  
    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Required, Range(0.01, 1000000)]
    public decimal Price { get; set; }
    [Required, Range(0, 1000000)]
    public int StockQuantity { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
}
public class UpdateProductDto
{
   
    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    [Required, Range(0.01, 1000000)]
    public decimal Price { get; set; }
    [Required, Range(0, 1000000)]
    public int StockQuantity { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
}
public class PatchProductDto
{
    [Required, Range(0, 1000000)]
    public int StockQuantity { get; set; }

}