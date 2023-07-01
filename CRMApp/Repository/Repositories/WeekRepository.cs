using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;


namespace Repository.Repositories
{
    public class WeekRepository : Repository<Week>, IWeekRepository
    {
        public WeekRepository(AppDbContext context) : base(context)
        {
        }


    }
}
