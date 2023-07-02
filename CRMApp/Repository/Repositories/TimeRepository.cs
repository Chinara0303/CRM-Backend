using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class TimeRepository : Repository<Time>, ITimeRepository
    {
        public TimeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Seans>> GetFullDataForSeansAsync(int seansId)
        {
            return await _entities.Include(m => m.Seans).Where(t => t.SeansId == seansId).Select(t => t.Seans).ToListAsync();
        }

    }
}
