using EcommerceSystem.Data;
using EcommerceSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Repos.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly EcommerceDb _context;

        public GenericRepo(EcommerceDb context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
