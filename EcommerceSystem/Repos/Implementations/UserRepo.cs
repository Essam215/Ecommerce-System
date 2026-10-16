using EcommerceSystem.Data;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;
using EcommerceSystem.Repos.Interfaces;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcommerceSystem.Repos.Implementations
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly EcommerceDb _context;
        private readonly IConfiguration _configaration;

        public UserRepo(EcommerceDb context, IConfiguration configaration) : base(context)
        {
            _context = context;
            _configaration = configaration;
        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configaration["Jwt:Key"]));
            var Claim = new List<Claim>
            {
                new Claim(ClaimTypes.Role , user.Role),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var signingCredintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: _configaration["Jwt:Issuer"],
                audience: _configaration["Jwt:Audience"],
                claims: Claim,
                signingCredentials: signingCredintials,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configaration["Jwt:DurationInHours"]))
                );
            return new JwtSecurityTokenHandler().WriteToken(token); 

        }

        public string Login(LoginDto dto)
        {
            var user = _context.Users.Where(u => u.Email == dto.Email && u.PasswordHash == dto.PasswordHash).First();
            var Token = GenerateToken(user);
            return Token;
        }
    }
}
