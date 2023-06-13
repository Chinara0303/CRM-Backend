using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface IPositionRepository:IRepository<Position>
    {
       Task<bool> CheckByName(string name);
       
    }
}
