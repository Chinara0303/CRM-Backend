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
    public class TeacherConfiguration:IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(s => s.FullName).IsRequired().HasMaxLength(300);
            builder.Property(s => s.Address).IsRequired();
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s => s.Biography).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Phone).IsRequired();
            builder.Property(s => s.Image).IsRequired();
        }
    }
}
