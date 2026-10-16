using AutoMapper;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;

namespace EcommerceSystem.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<GetOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
        }
    }
}
