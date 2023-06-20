using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;
namespace Repository.Repositories
{
    public class SiteSocialRepository : Repository<SiteSocial>, ISiteSocialRepository
    {
        public SiteSocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
