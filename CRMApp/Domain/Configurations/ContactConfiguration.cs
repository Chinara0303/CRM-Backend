using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.FullName).IsRequired();
            builder.Property(c => c.EducationId).IsRequired();
            builder.Property(c => c.Message).IsRequired();
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.Email).IsRequired();
        }
    }
}
