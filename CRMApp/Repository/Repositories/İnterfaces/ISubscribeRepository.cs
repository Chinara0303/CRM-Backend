using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface ISubscribeRepository:IRepository<Subscribe>
    {
        Task<bool> CheckByEmail(string emailAddress);
    }
}
