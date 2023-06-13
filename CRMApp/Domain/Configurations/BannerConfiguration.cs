using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.Configurations
{
    public class BannerConfiguration
    {
        //: IEntityTypeConfiguration<Banner>
        //public void Configure(EntityTypeBuilder<Banner> builder)
        //{
        //    builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
        //    builder.Property(b => b.Description).IsRequired();
        //    builder.Property(b => b.Offer).IsRequired(false);
        //}
    }
}
