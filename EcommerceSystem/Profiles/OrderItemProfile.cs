using AutoMapper;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;

namespace EcommerceSystem.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile() {
            CreateMap<CreateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<GetOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<UpdateOrderItemDto, OrderItem>().ReverseMap();
            CreateMap<CreateOrderItemwithOrderDto, OrderItem>().ReverseMap();
            CreateMap<CreateOrderwithOrderItemDto, Order>().ReverseMap(); // maybe switch
        }
    }
}
