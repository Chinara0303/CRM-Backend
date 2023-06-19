using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class SocialRepository : Repository<Social>, ISocialRepository
    {
        public SocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
