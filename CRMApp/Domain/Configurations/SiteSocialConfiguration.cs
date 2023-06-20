using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SiteSocialConfiguration : IEntityTypeConfiguration<SiteSocial>
    {
        public void Configure(EntityTypeBuilder<SiteSocial> builder)
        {
            builder.Property(s => s.Link).IsRequired();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.IconName).IsRequired();
        }
    }
}
