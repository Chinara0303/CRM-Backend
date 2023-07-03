using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context)
        {
        }

        public Dictionary<string, string> GetAll()
        {
            return _entities.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
