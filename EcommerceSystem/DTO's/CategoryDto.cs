using EcommerceSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.DTO_s;
    public class GetCategoryDto
    {
    [Key]
    public int Id { get; set; }
    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }

}
public class CreateCategoryDto
{
  
    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }

}
public class UpdateCategoryDto
{
  
    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Description { get; set; }

}

