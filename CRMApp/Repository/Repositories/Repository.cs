using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
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
            if (entity is null) throw new ArgumentException(nameof(entity));
            await _entities.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? await _entities.Where(expression).ToListAsync() : await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            T entity = await _entities.FindAsync(id);
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return entity;
        }

        public async Task SoftDeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            T entity = await _entities.FindAsync(id);
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            entity.SoftDelete = true;
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    
    }
}
