using Domain.Common;
using System.Linq.Expressions;

namespace Repository.Repositories.İnterfaces
{
    public interface ISearchRepository<T> where T : BaseEntity
    {
        IEnumerable<T> SearchAsync(Func<T, bool> predicate);
        //Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
    }
}
