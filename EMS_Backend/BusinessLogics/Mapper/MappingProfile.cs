using AutoMapper;
using BusinessLogics.Models.RequestModels;
using DataAccessLayer.Models;

namespace BusinessLogics.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequest, UserEntity>().ReverseMap();
        }
    }
}
