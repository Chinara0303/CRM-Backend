using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).HasMaxLength(50).IsRequired();
            builder.Property(g => g.RoomId).IsRequired();
            builder.Property(g => g.Weekday).IsRequired();
            builder.Property(g => g.Seans).IsRequired();
            builder.Property(g => g.CourseId).IsRequired();

        }
    }
}
