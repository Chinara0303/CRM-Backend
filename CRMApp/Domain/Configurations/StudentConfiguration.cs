using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FullName).IsRequired();
            builder.Property(s => s.Address).IsRequired();
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s => s.GroupId).IsRequired();
            builder.Property(s => s.Biography).IsRequired();
            builder.Property(s => s.Email).IsRequired();
        }
    }
}
