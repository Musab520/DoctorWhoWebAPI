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
        public async Task<IEnumerable<Episode>> GetDoctorsAsync()
        {
            return await _context.episodes.ToListAsync();
        }

        public async Task InsertDoctorAsync(Episode episode)
        {
           await _context.episodes.AddAsync(episode);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
