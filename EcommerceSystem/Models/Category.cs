using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Models
{
    [Index(nameof(Name), IsUnique =  true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(2), MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public List<Product> products { get; set; } = new List<Product>();
    }
}
