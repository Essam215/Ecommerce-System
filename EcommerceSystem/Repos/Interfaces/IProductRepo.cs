using EcommerceSystem.Models;

namespace EcommerceSystem.Repos.Interfaces
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        public Task<List<Product>> Pagination(int ?categoryId, int page, int pageSize, string? SortBy);
        public Task<Product> SecondExpensive(int categoryId);
        public Task<List<Product>> Search(string Name);
    }
}
