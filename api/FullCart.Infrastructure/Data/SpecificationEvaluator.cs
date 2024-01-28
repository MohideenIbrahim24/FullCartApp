using FullCart.Domain;
using FullCart.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace FullCart.Infrastructure;

public class SpecificationEvaluator<TDataEntity> where TDataEntity : BaseEntity
{
    public static IQueryable<TDataEntity> GetQuery(IQueryable<TDataEntity> inputQuery, ISpecification<TDataEntity> spec)
    {
        var Query = inputQuery.AsQueryable();
        if (spec.Criteria != null)
        {
            Query = Query.Where(spec.Criteria);
        }
        if (spec.OrderBy != null)
        {
            Query = Query.OrderBy(spec.OrderBy);
        }
        if (spec.OrderByDescending != null)
        {
            Query = Query.OrderByDescending(spec.OrderByDescending);
        }
        if (spec.isPagingEnabled != null)
        {
            Query = Query.Skip(spec.Skip).Take(spec.Take);
        }
        Query = spec.Includes.Aggregate(Query, (current, include) => current.Include(include));
        return Query;
    }
}
