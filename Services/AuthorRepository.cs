using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public async Task<Author?> GetAuthorAsync(int AuthorId)
        {
            return await _context.authors.FirstOrDefaultAsync(author => author.AuthorId == AuthorId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
