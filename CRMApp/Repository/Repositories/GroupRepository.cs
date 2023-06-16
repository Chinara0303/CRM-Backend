using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;
namespace Repository.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
