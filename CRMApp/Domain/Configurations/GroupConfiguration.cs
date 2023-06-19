using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).HasMaxLength(50).IsRequired();
            builder.Property(g => g.RoomId).IsRequired();
            builder.Property(g => g.Weekday).IsRequired();
            builder.Property(g => g.TimeId).IsRequired();
            builder.Property(g => g.EducationId).IsRequired();

        }
    }
}
