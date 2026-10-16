using EcommerceSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.DTO_s;
public class GetOrderItemDto
{
    [Key]
    public int Id { get; set; }
    [Required, Range(1, 1000)]
    public int Quantity { get; set; }
    [Required, Range(0.01, 1000000)]
    public decimal UnitPrice { get; set; }
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
}

public class CreateOrderItemDto
{
  
    [Required, Range(1, 1000)]
    public int Quantity { get; set; }
    [Required, Range(0.01, 1000000)]
    public decimal UnitPrice { get; set; }
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
}
public class UpdateOrderItemDto
{
  
    [Required, Range(1, 1000)]
    public int Quantity { get; set; }
    [Required, Range(0.01, 1000000)]
    public decimal UnitPrice { get; set; }
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
}

public class CreateOrderwithOrderItemDto
{
    public List<CreateOrderItemwithOrderDto> Items { get; set; }
}

public class CreateOrderItemwithOrderDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}