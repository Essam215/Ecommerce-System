using AutoMapper;
using EcommerceSystem.DTO_s;
using EcommerceSystem.Models;

namespace EcommerceSystem.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
            CreateMap<GetUserDto, User>().ReverseMap();
            CreateMap<LoginDto, User>().ReverseMap();
        }
    }
}
