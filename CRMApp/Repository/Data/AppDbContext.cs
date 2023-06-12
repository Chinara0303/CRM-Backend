using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Seans> Seanses { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Weekday> Weekdays { get; set; }
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        public DbSet<StaffPosition> StaffPositions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Course>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<About>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Banner>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Group>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Position>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Room>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Seans>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Setting>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Slider>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Social>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Staff>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Teacher>().HasQueryFilter(c => !c.SoftDelete);
            builder.Entity<Student>().HasQueryFilter(c => !c.SoftDelete);

            base.OnModelCreating(builder);
        }
    }
}
