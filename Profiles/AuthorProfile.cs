using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.DtoModels;

namespace DoctorWho.Web.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorForUpdateDto,Author>();
        }
    }
}
