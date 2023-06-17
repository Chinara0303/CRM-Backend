using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class TimeRepository : Repository<Time>, ITimeRepository
    {
        public TimeRepository(AppDbContext context) : base(context) { }
        
    }
}
