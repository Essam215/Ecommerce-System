namespace EcommerceSystem.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task AddAsync(T entity);
        public void Delete(T entity);
        public void Update(T entity);
    }
}
