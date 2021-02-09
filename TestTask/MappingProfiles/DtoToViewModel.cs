using AutoMapper;
using TestTask.Dtos;
using TestTask.Models;

namespace TestTask.MappingProfiles
{
    public class DtoToViewModel : Profile
    {
        public DtoToViewModel()
        {
            CreateMap<GetUserDto, GetUserViewModel>().ReverseMap();

            CreateMap<UpdateUserDto, UpdateUserViewModel>().ReverseMap();

            CreateMap<CreateUserDto, CreateUserViewModel>().ReverseMap();
        }
    }
}
