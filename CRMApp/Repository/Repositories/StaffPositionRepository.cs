using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class StaffPositionRepository : Repository<StaffPosition>, IStaffPositionRepository
    {
        public StaffPositionRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
