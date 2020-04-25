using System.Reflection;
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
        public DbSet<TitleType> TitleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}