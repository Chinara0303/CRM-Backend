using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.Configurations
{
    public class AboutConfiguration:IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(200).IsRequired();
            builder.Property(a => a.SubTitle).IsRequired(false);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(250);
        }
    }
}
