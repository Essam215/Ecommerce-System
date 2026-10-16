using AutoMapper;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;
using EcommerceSystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.categoryRepo.GetAllAsync();
            if (categories.Count == 0) return NotFound();
            var dto = _mapper.Map<List<DTO_s.GetCategoryDto>>(categories);

            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            await _unitOfWork.categoryRepo.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return Created();
        }
    }
}
