using AutoMapper;
using BusinessLogics.Models.RequestModels;
using BusinessLogics.Models.ViewModels;
using DataAccessLayer.Models;

namespace BusinessLogics.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequest, UserEntity>().ReverseMap();
            CreateMap<UserEntity, Employees>().ReverseMap();
            CreateMap<DesignationEntity, ConfigView>().ReverseMap();
            CreateMap<PayslipRequest, PayslipEntity>().ReverseMap();
        }
    }
}
