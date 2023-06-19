using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface ITeacherRepository:IRepository<Teacher>
    {
        Task<bool> CheckByEmail(string emailAddress);

    }
}
