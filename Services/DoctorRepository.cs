using DoctorWho.Db;
using DoctorWho.Web.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Web
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteDoctorAsync(Doctor doctor)
        { 
                _context.doctors.Remove(doctor);  
        }

        public async Task<bool> DoctorExistsAsync(int DoctorId)
        {
            return await _context.doctors.Where(d => d.DoctorId == DoctorId).FirstOrDefaultAsync() is not null;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.doctors.ToListAsync();
        }
        public async Task<Doctor?> GetDoctorAsync(int DoctorId)
        {

            return await _context.doctors.Where(d => d.DoctorId == DoctorId).FirstOrDefaultAsync();
        }

        public async Task InsertDoctorAsync(Doctor doctor)
        {
             await _context.doctors.AddAsync(doctor);      
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
