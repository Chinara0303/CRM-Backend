using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class SeansRepository : Repository<Seans>, ISeansRepository
    {
        public SeansRepository(AppDbContext context) : base(context)
        {
        }
    }
}
