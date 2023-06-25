using Domain.Common;
using Domain.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class SearchRepository<T> : ISearchRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public readonly DbSet<T> _entities;
        public SearchRepository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public IEnumerable<T> SearchAsync(Func<T, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            return _entities.Where(predicate).ToList();
        }
        
    }
}
