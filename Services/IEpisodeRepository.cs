using DoctorWho.Db;
using DoctorWho.Web.DtoModels;

namespace DoctorWho.Web.Services
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<Episode>> GetEpisodesAsync();
        Task<Episode> GetEpisodeAsync(int episodeId);
        public Task<Enemy?> GetEnemyAsync(int enemyId);
        public Task<Companion?> GetCompanionAsync(int companionId);
        Task InsertEpisodeAsync(Episode episode);
        Task InsertEnemytoEpisodeAsync(EpisodeEnemy episodeEnemy);
        Task InsertCompaniontoEpisodeAsync(EpisodeCompanion episodeCompanion);
        Task<bool> SaveChangesAsync();
    }
}
