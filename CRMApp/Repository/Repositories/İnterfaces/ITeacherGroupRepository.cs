using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface ITeacherGroupRepository:IRepository<TeacherGroup>
    {
        Task<IEnumerable<Teacher>> GetFullDataForTeacherAsync(int groupId);
        Task<IEnumerable<Group>> GetFullDataForGroupAsync(int teacherId);
    }
}
