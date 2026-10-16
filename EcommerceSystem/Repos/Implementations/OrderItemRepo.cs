using EcommerceSystem.Data;
using EcommerceSystem.Models;
using EcommerceSystem.Repos.Interfaces;

namespace EcommerceSystem.Repos.Implementations
{
    public class OrderItemRepo : GenericRepo<OrderItem>, IOrderItemRepo
    {
        private readonly EcommerceDb _context;

        public OrderItemRepo(EcommerceDb context) : base(context)
        {
            _context = context;
        }
    }
}
