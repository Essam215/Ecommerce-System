using EcommerceSystem.Repos.Interfaces;

namespace EcommerceSystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategoryRepo categoryRepo { get; }
        public IOrderRepo orderRepo { get; }
        public IOrderItemRepo orderItemRepo { get; }
        public IProductRepo productRepo { get; }
        public IUserRepo userRepo { get; }

        public Task<int> SaveChangesAsync();
    }
}
