using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
