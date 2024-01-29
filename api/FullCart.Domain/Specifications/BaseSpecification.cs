using System.Linq.Expressions;

namespace FullCart.Domain;

public class BaseSpecification<T> : ISpecification<T>
{

    public Expression<Func<T, bool>> Criteria { get; }
    public BaseSpecification()
    {

    }
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }
    public List<Expression<Func<T, object>>> Includes { get; }
    = new List<Expression<Func<T, object>>>();

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool isPagingEnabled { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    public void AddOrderBy(Expression<Func<T, object>> OrderByexpression)
    {
        OrderBy = OrderByexpression;
    }
    public void AddOrderByDecending(Expression<Func<T, object>> OrderByDecending)
    {
        OrderByDescending = OrderByDecending;
    }
    public void ApplyPaging(int skip, int take)
    {        
        Skip = skip;
        Take = take;
        isPagingEnabled = true;
    }
}
