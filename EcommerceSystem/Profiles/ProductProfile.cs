using AutoMapper;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;

namespace EcommerceSystem.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<GetProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<PatchProductDto, Product>().ReverseMap();
        }
    }
}
