using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;
namespace Repository.Repositories
{
    public class StaffSocialRepository : Repository<StaffSocial>, IStaffSocialRepository
    {
        public StaffSocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
