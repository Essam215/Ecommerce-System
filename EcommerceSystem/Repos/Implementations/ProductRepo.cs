using EcommerceSystem.Data;
using EcommerceSystem.Models;
using EcommerceSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Repos.Implementations
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly EcommerceDb _context;

        public ProductRepo(EcommerceDb context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Product>> Pagination(int ?categoryId, int page, int pageSize, string? SortBy)
        {
            var products = _context.Products.AsQueryable();
            if (categoryId.HasValue) products = products.Where(p => p.CategoryId == categoryId.Value);
            products = SortBy.ToLower() switch
            {
                "name" => products.OrderBy(p => p.Name),
                "price" => products.OrderBy(p => p.Price),
                "" => products.OrderBy(p => p.Id),
                _ => products.OrderBy(p => p.Id)
            };

            products =  products.Skip((page - 1) * pageSize).Take(pageSize);
            return await products.ToListAsync();
        }

        public async Task<List<Product>> Search(string Name)
        {
            var product = await _context.Products.Where(s => s.Name.ToLower().Contains(Name.ToLower())).ToListAsync();
            return product;
        }

        public async Task<Product> SecondExpensive(int categoryId)
        {
            var products = await _context.Products.Where(p => p.CategoryId != categoryId).OrderByDescending(p => p.Price).Skip(1).FirstOrDefaultAsync();
            return products;
        }


    }
}
