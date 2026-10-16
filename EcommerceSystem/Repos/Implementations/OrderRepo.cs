using EcommerceSystem.Data;
using EcommerceSystem.Models;
using EcommerceSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Repos.Implementations
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly EcommerceDb _context;

        public OrderRepo(EcommerceDb context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> TotalRevenue()
        {
            var revenue =  _context.Orders.Where(s => s.Status == "Completed").SumAsync(s => s.TotalAmount);
            return await revenue;
        }
    }
}
