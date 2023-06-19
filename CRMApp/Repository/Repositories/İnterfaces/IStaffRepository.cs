using Domain.Entities;
namespace Repository.Repositories.İnterfaces
{
    public interface IStaffRepository:IRepository<Staff>
    {
        Task<bool> CheckByEmail(string emailAddress);
    }
}
