using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IDoctorRepository
    {
         Task<Doctor> GetDoctorByIdAsync(int id);
         Task<IReadOnlyList<Doctor>> GetDoctorsAsync();
         Task<IReadOnlyList<TitleType>> GetTitleAsync();

    }
}