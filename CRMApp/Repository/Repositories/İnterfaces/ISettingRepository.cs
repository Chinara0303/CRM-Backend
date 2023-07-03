using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface ISettingRepository:IRepository<Setting>
    {
        Dictionary<string, string> GetAll();
    }
}
