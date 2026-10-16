using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;
using Microsoft.Identity.Client;

namespace EcommerceSystem.Repos.Interfaces
{
    public interface IUserRepo : IGenericRepo<User>
    {
        public string Login(LoginDto dto);
    }
}
