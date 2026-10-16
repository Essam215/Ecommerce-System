using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceSystem.DTO_s;
    public class GetOrderDto
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
}
public class CreateOrderDto
{
   
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
}
public class UpdateOrderDto
{
 
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
}

public class PatchOrderDto
{
    public string Status { get; set; }
}