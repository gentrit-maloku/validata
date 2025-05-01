using Microsoft.EntityFrameworkCore;
using Validata.Application.Interfaces.Common;

namespace Validata.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ValidataDbContext _context;

        private readonly DbSet<T> _entities;

        public Repository(ValidataDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id) => await _entities.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.AsNoTracking().ToListAsync();

        public async Task AddAsync(T entity) => await  _entities.AddAsync(entity);

        public void Remove(T entity) => _entities.Remove(entity);
    }
}
