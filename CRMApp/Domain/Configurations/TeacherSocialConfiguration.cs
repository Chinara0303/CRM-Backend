using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class TeacherSocialConfiguration : IEntityTypeConfiguration<TeacherSocial>
    {
        public void Configure(EntityTypeBuilder<TeacherSocial> builder)
        {
            builder.Property(s => s.Link).IsRequired();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.TeacherId).IsRequired();
        }
    }
}
