using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Repository.Repositories.İnterfaces
{
    public interface IAccountRepository<T> where T : IdentityUser
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(T entity);
        Task SaveAsync();
    }
}
