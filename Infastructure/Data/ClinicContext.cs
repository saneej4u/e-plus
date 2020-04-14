using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options):base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
    }
}