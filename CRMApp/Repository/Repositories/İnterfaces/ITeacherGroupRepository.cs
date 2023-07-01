using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface ITeacherGroupRepository:IRepository<TeacherGroup>
    {
        Task<IEnumerable<Group>> GetFullDataAsync();
    }
}
