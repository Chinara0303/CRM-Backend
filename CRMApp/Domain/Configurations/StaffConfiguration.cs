using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(300);
            builder.Property(s => s.Address).IsRequired();
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s => s.Biography).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Phone).IsRequired();
            builder.Property(s => s.Image).IsRequired();
        }
    }
}
