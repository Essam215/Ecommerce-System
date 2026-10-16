using AutoMapper;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;
using EcommerceSystem.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcommerceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles ="Customer")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            if (order == null) return NotFound();
            await _unitOfWork.orderRepo.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return Created("", order);
        }

        [HttpPatch] 
        public async Task<IActionResult> PatchOrder(int id, PatchOrderDto dto)
        {
            if (dto.Status != "Pending" && dto.Status != "Completed" && dto.Status != "Cancelled") return BadRequest("Status must be Pending, Completed, or Cancelled");

            var order = await _unitOfWork.orderRepo.GetByIdAsync(id);
            if (order == null) return NotFound();
            _mapper.Map(dto, order);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<GetOrderDto>(order));
        }
        [HttpGet("calculateRevenue")]
        public async Task<IActionResult> Revenue()
        {
            var revenue = await _unitOfWork.orderRepo.TotalRevenue();
            return Ok(revenue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _unitOfWork.orderRepo.GetByIdAsync(id);

            if (order == null) return NotFound();
            var dto = _mapper.Map<GetOrderDto>(order);

            return Ok(dto);
        } 
    }
}
