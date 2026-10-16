using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(1, 1000)]
        public int Quantity { get; set; }
        [Required, Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        
    }
}
