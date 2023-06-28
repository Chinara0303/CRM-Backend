using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Seans> Seanses { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TeacherSocial> TeacherSocials { get; set; }
        public DbSet<SiteSocial> SiteSocials { get; set; }
        public DbSet<StaffSocial> StaffSocials { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        public DbSet<StaffPosition> StaffPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<Position>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Room>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Seans>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Teacher>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Education>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Student>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Staff>().HasQueryFilter(p => !p.SoftDelete);
            builder.Entity<Group>().HasQueryFilter(p => !p.SoftDelete);

            builder.Entity<Setting>().HasData(new Setting
            {
                Id = 1,
                Key = "Phone",
                Value = "123-123-1234"
            },
            new Setting
            {
                Id = 2,
                Key = "EmailAdress",
                Value = "webfull@edu.com"
            },
            new Setting
            {
                Id = 3,
                Key = "Logo",
                Value = "download.jpg"
            },
            new Setting
            { 
                Id = 4,
                Key = "Address",
                Value = "132 Jefferson Avenue, Suite 22, Redwood City, CA 94872"
            },
            new Setting
            {
                Id = 5,
                Key = "Fax",
                Value = "123-323-3343"
            },
            new Setting
            { 
                Id = 6,
                Key = "TollFree",
                Value = "123-425-6234"
            });
        }
    }
}
