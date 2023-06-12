using Domain.Common;
using System.Linq.Expressions;

namespace Repository.Repositories.İnterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int? id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(int? id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task SaveAsync();
        //Task<bool> CheckByName(string name);
        //public async Task<bool> CheckByName(string name)
        //{
        //    return await _entities.AnyAsync(c => c.Name.Trim().ToLower() == name.Trim().ToLower());
        //}

    }
}
