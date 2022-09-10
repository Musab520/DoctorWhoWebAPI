using DoctorWho.Db;
using DoctorWho.Web.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Services
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public async Task<IEnumerable<Episode>> GetEpisodesAsync()
        {
            return await _context.episodes.ToListAsync();
        }
        public async Task<Episode?> GetEpisodeAsync(int episodeId)
        {
            return await _context.episodes.FirstOrDefaultAsync(episode => episode.EpisodeId == episodeId);
        }
        public async Task<Enemy?> GetEnemyAsync(int enemyId)
        {
            return await _context.enemies.FirstOrDefaultAsync(enemy => enemy.EnemyId == enemyId);
        }
        public async Task<Companion?> GetCompanionAsync(int companionId)
        {
            return await _context.companions.FirstOrDefaultAsync(companion => companion.CompanionId == companionId);
        }
        public async Task InsertEpisodeAsync(Episode episode)
        {
           await _context.episodes.AddAsync(episode);
        }
        public async Task InsertEnemytoEpisodeAsync(EpisodeEnemy episodeEnemy)
        {
            
            await _context.episodesEnemies.AddAsync(episodeEnemy);
        }
        public async Task InsertCompaniontoEpisodeAsync(EpisodeCompanion episodeCompanion)
        {
            await _context.episodesCompanions.AddAsync(episodeCompanion);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
