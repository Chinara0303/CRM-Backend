using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(s => s.Title).HasMaxLength(200).IsRequired();
            builder.Property(s => s.SubTitle).HasMaxLength(500).IsRequired();
            builder.Property(s => s.Image).IsRequired();
        }
    }
}
