using Domain.Common;
using Domain.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Helpers;
using Repository.Repositories.İnterfaces;
using System.Linq.Expressions;


namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public readonly DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            await _entities.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? await _entities.Where(expression).ToListAsync() : await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            T entity = await _entities.FindAsync(id);
            return entity is null ? throw new NullReferenceException(ExceptionResponseMessages.NotFoundMessage) : entity;
        }

        public async Task SoftDeleteAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            entity.SoftDelete = true;
            entity.DeletedDate = DateTime.UtcNow.AddHours(4);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
             ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            _entities.Update(entity);
            entity.ModifiedDate = DateTime.UtcNow.AddHours(4);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            return await _entities.IncludeMultiple(includes).ToListAsync();
        }
    }
}
