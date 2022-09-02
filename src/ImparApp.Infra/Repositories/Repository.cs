using ImparApp.Domain.Models;
using ImparApp.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImparApp.Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ImparContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ImparContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> InsertAllAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);

            await SaveChangesAsync();

            return entities;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await SaveChangesAsync();
        }

        public async Task DeleteAllAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
