using FullCart.Domain;
using FullCart.Domain.Common;

namespace FullCart.Application;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);

    Task<T> GetEntityWithSpec(ISpecification<T> specification);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
    Task<int> CountAsync(ISpecification<T> specifications);
    void DeleteAsync(T entity);
    void UpdateAsync(T entity);

    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
