using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface IContactRepository:IRepository<Contact>
    {
        Task<bool> CheckByEmail(string emailAddress);
    }
}
