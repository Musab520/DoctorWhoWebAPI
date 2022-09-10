using DoctorWho.Db;
using DoctorWho.Web.DtoModels;

namespace DoctorWho.Web.Services
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetDoctorsAsync();
        Task InsertDoctorAsync(Episode episode);
        Task<bool> SaveChangesAsync();
    }
}
