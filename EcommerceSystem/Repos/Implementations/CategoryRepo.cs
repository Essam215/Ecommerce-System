using EcommerceSystem.Data;
using EcommerceSystem.Models;
using EcommerceSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Repos.Implementations
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly EcommerceDb _context;
        public CategoryRepo(EcommerceDb context) : base(context)
        {
            _context = context;
        }

      
    }
}
