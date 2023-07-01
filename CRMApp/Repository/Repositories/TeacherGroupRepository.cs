using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class TeacherGroupRepository : Repository<TeacherGroup>, ITeacherGroupRepository
    {
      
        public TeacherGroupRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Group>> GetFullDataAsync()
        {
            return await _entities.Include(m => m.Group).Include(m => m.Teacher).Select(m => m.Group).ToListAsync();
        }
    }
}
