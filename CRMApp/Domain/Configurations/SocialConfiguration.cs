using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SocialConfiguration : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.Property(s => s.Link).IsRequired();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.TeacherId).IsRequired();
        }
    }
}
