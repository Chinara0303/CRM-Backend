using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class TeacherGroupRepository : Repository<TeacherGroup>, ITeacherGroupRepository
    {
      
        public TeacherGroupRepository(AppDbContext context) : base(context)
        {
            
        }

    }
}
