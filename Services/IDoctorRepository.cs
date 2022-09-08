
using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Web
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task InsertDoctorAsync(Doctor doctor);
        void DeleteDoctorAsync(Doctor doctor);
        Task<bool> DoctorExistsAsync(int DoctorId);
        Task<bool> SaveChangesAsync();
        Task<Doctor?> GetDoctorAsync(int DoctorId);
    }
}
