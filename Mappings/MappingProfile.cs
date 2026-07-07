using AutoMapper;
using MyBackend.Models;
using MyBackend.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBackend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // хэшируем отдельно
            CreateMap<UpdateUserRequest, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}