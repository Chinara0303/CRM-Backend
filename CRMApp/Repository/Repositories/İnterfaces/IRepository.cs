using Domain.Common;
using System.Linq.Expressions;

namespace Repository.Repositories.İnterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int? id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task SaveAsync();
        Task<IEnumerable<T>> GetAllWithIncludes(params Expression<Func<T, object>>[] includes);

    }
}
