using EcommerceSystem.Data;
using EcommerceSystem.Repos.Interfaces;

namespace EcommerceSystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDb _context;

        public UnitOfWork(EcommerceDb context, ICategoryRepo categoryRepo, IOrderRepo orderRepo, IOrderItemRepo orderItemRepo, IProductRepo productRepo, IUserRepo userRepo)
        {
            _context = context;
            this.categoryRepo = categoryRepo;
            this.orderRepo = orderRepo;
            this.orderItemRepo = orderItemRepo;
            this.productRepo = productRepo;
            this.userRepo = userRepo;
        }

        public ICategoryRepo categoryRepo { get; }
        public IOrderRepo orderRepo { get; }
        public IOrderItemRepo orderItemRepo { get; }
        public IProductRepo productRepo { get; }
        public IUserRepo userRepo { get; }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
