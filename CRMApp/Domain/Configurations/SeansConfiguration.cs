using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class SeansConfiguration : IEntityTypeConfiguration<Seans>
    {
        public void Configure(EntityTypeBuilder<Seans> builder)
        {
            builder.Property(s => s.Id).IsRequired();
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
