using DoctorWho.Web.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Web
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorDto>> GetDoctorsAsync();
        Task InsertDoctorAsync(int DoctorId,DoctorForInsertDto doctor);
        Task UpdateDoctorAsync(int DoctorId,DoctorForUpdateDto doctor);
        void DeleteDoctorAsync(int DoctorId);
        Task<bool> DoctorExistsAsync(int DoctorId);
    }
}
