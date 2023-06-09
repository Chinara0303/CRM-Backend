﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Promise).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Duration).IsRequired();
            builder.Property(c => c.Image).IsRequired();
        }
    }
}
