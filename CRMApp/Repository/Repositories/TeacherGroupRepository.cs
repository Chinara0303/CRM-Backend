using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class TeacherGroupRepository : Repository<TeacherGroup>, ITeacherGroupRepository
    {
      
        public TeacherGroupRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Teacher>> GetFullDataForTeacherAsync(int groupId)
        {
            return await _entities.Include(m => m.Teacher).Where(t => t.GroupId == groupId).Select(t => t.Teacher).ToListAsync();
        }
        public async Task<IEnumerable<Group>> GetFullDataForGroupAsync(int teacherId)
        {
            return await _entities.Include(m => m.Group).Where(t => t.TeacherId == teacherId).Select(t => t.Group).ToListAsync();
        }
    }
}
