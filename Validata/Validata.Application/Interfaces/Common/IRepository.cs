namespace Validata.Application.Interfaces.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        void Remove(T entity);
    }
}
