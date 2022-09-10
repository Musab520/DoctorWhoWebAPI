using DoctorWho.Db;

namespace DoctorWho.Web.Services
{
    public interface IAuthorRepository
    {
        Task<bool> SaveChangesAsync();
        Task<Author?> GetAuthorAsync(int AuthorId);

    }
}
