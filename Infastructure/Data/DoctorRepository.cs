using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Data
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicContext _context;
        public DoctorRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors
                        .Include(d => d.Title)
                        .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IReadOnlyList<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors
                        .Include(d => d.Title)
                        .ToListAsync();
        }

        public async Task<IReadOnlyList<TitleType>> GetTitleAsync()
        {
            return await _context.TitleTypes.ToListAsync();
        }
    }
}