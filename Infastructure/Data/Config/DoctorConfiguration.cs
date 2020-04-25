using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Data.Config
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
           builder.Property(d => d.FirstName).IsRequired().HasMaxLength(20);
           builder.Property(d => d.LastName).IsRequired().HasMaxLength(50);
        }
    }
}