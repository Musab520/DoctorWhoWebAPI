using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.DtoModels;

namespace DoctorWho.Web.Profiles
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeForInsertDto,Episode>();
            CreateMap<EpisodeEnemyDto,EpisodeEnemy>();
            CreateMap<EpisodeCompanionDto, EpisodeCompanion>();
        }
    }
}
