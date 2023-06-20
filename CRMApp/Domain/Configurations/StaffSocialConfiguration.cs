using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Domain.Configurations
{
    public class StaffSocialConfiguration : IEntityTypeConfiguration<StaffSocial>
    {
        public void Configure(EntityTypeBuilder<StaffSocial> builder)
        {
            builder.Property(s => s.Link).IsRequired();
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
