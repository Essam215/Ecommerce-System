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
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Pagination")]

        public async Task<IActionResult> Pagination(int ?categoryId, int page, int pageSize, string ?SortBy)
        {
            var categories = await _unitOfWork.productRepo.Pagination(categoryId, page, pageSize, SortBy);

            var dto = _mapper.Map<List<GetProductDto>>(categories);
            return Ok(dto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product =await  _unitOfWork.productRepo.GetByIdAsync(id);

            if (product == null) return NotFound();

            var dto = _mapper.Map<GetProductDto>(product);

            return Ok(dto);
        }

        [HttpGet("Second-Most-Expensive-Excluding-Category")]
        public async Task<IActionResult> SecondMostExpensiveExcludingCategory([FromQuery] int categoryId)
        {
            var product = await _unitOfWork.productRepo.SecondExpensive(categoryId);

            if (product == null) return NotFound();

            var dto = _mapper.Map<GetProductDto>(product);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var category = _unitOfWork.productRepo.GetByIdAsync(dto.CategoryId);

            if (category == null) return NotFound();
            var product = _mapper.Map<Product>(dto);

            await _unitOfWork.productRepo.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
        {
            var product = await _unitOfWork.productRepo.GetByIdAsync(id);
            if (product == null) return NotFound();

            var category = await _unitOfWork.categoryRepo.GetByIdAsync(dto.CategoryId);

            if (category == null) return NotFound();

            _mapper.Map(dto, product);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(int id, PatchProductDto dto)
        {
            var product = await _unitOfWork.productRepo.GetByIdAsync(id);
            if (product == null) return NotFound();
            _mapper.Map(dto, product);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<GetProductDto>(product));
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Name)
        {
            var products = await _unitOfWork.productRepo.Search(Name);
            if (products.Count() == 0) return NotFound();
            var dto = _mapper.Map<List<GetProductDto>>(products);
            return Ok(dto);
        }
     
    }
}
