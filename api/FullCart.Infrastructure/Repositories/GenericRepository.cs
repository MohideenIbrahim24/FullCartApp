using FullCart.Application;
using FullCart.Domain;
using FullCart.Domain.Common;
using FullCart.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FullCart.Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly CartDbContext _cartDbContext;

    public GenericRepository(CartDbContext cartDbContext)
    {
        _cartDbContext = cartDbContext;
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        try
        {
            return await _cartDbContext.Set<T>().ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        try
        {
            var result = await _cartDbContext.Set<T>().FindAsync(id);
            return result!;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }
    public async Task<int> CountAsync(ISpecification<T> specifications)
    {
        return await ApplySpecification(specifications).CountAsync();
    }
    private IQueryable<T> ApplySpecification(ISpecification<T> specifications)
    {
        return SpecificationEvaluator<T>.GetQuery(_cartDbContext.Set<T>().AsQueryable(), specifications);
    }

    public void Add(T entity)
    {
        _cartDbContext.Add<T>(entity);
    }

    public void Update(T entity)
    {
        _cartDbContext.Attach<T>(entity);
        _cartDbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _cartDbContext.Set<T>().Remove(entity);
    }

    public void DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
