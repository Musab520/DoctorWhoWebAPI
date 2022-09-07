using DoctorWho.Db;
using DoctorWho.Web.DtoModels;

namespace DoctorWho.Web.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteDoctorAsync(int DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoctorExistsAsync(int DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoctorDto>> GetDoctorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertDoctorAsync(int DoctorId, DoctorForInsertDto doctor)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctorAsync(int DoctorId, DoctorForUpdateDto doctor)
        {
            throw new NotImplementedException();
        }
    }
}
