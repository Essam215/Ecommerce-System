using EcommerceSystem.Models;
using EcommerceSystem.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public IActionResult Login(DTO_s.LoginDto dto)
        {
            var token = _unitOfWork.userRepo.Login(dto);
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(DTO_s.RegisterDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                PasswordHash = dto.PasswordHash,
                Role = "Customer"
            };
            await _unitOfWork.userRepo.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Created();
        }
    }
}