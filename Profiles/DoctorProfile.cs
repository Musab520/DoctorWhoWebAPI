using AutoMapper;
using DoctorWho.Db;

namespace DoctorWho{ 
    public class DoctorProfile :Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, Web.DtoModels.DoctorDto>();
            CreateMap<Web.DtoModels.DoctorForInsertDto,Doctor>();
            CreateMap<Web.DtoModels.DoctorForUpdateDto,Doctor>();
        }
        
    }
}

