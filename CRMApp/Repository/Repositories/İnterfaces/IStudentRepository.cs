using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface IStudentRepository:IRepository<Student>
    {
        Task<bool> CheckByEmail(string emailAddress);
    }
}
