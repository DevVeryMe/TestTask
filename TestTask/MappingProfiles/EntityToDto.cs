using AutoMapper;
using TestTask.Dtos;
using TestTask.Entities;

namespace TestTask.MappingProfiles
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<UserEntity, GetUserDto>().ReverseMap();

            CreateMap<UserEntity, UpdateUserDto>().ReverseMap();

            CreateMap<UserEntity, CreateUserDto>().ReverseMap();
        }
    }
}
