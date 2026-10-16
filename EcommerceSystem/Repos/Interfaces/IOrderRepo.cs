using EcommerceSystem.Models;

namespace EcommerceSystem.Repos.Interfaces
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        public Task<decimal> TotalRevenue();
    }
}
