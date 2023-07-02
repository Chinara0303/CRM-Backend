using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface ITimeRepository:IRepository<Time>
    {
        Task<IEnumerable<Seans>> GetFullDataForSeansAsync(int seansId);
    }
}
