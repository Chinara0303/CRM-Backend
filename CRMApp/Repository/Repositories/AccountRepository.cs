using Domain.Common.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Repository.Repositories
{
    public class AccountRepository<T> : IAccountRepository<T> where T : AppUser
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression != null
                ? await _entities.Where(expression).ToListAsync()
                : await _entities.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);

            _entities.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(ExceptionResponseMessages.ParametrNotFoundMessage);
            entity.SoftDelete = true;
            await _context.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
