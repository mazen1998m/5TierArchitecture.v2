using app.core.EntityAndDtoStructure.EntityStructure;
using System.Linq.Expressions;
using System.Reflection;

namespace App.core.Filter;
public class Filter<TType> : FilterBase<TType>, IFilter<TType>
where TType : Entity
{
    private List<MethodInfo> _includeMethods;

    public IQueryable<TType> ApplyFilter(IQueryable<TType> query)
        => BackEndFilter ? ApplyBackEndFilter(query) : ApplyFrontEndFilter(query);



    #region FrontEnd Filter

    private IQueryable<TType> ApplyFrontEndFilter(IQueryable<TType> query)
    {
        if (BackEndFilter) return query;

        ReadMethod();
        if (!_includeMethods.Any()) return query;

        foreach (var method in _includeMethods)
        {
            if (FilterByAll || FilterBy.Contains("FilterByAll") || FilterBy.Contains("Filter By All")
                || FilterBy.Contains("Filter By All") || FilterBy.Contains("filter by all")
               )
            {
                query = (IQueryable<TType>)method.Invoke(this, null)!;
                continue;
            }

            if (!FilterBy.Any()) break;


            if (FilterBy.Contains(method.Name))
            {
                query = (IQueryable<TType>)method.Invoke(this, null)!;
            }

        }


        query = ApplySorting(query);

        query = ApplyPageing(query);

        return query;
    }


    protected void AddToFilter(bool notNull, string methodName)
    {
        if (notNull) FilterBy.Add(methodName);
    }




    protected override void ApplyFilter() => throw new NotImplementedException();


    #endregion



    #region BackEnd Filter

    private IQueryable<TType> ApplyBackEndFilter(IQueryable<TType> query)
    {
        if (Filter is null) return query;
        query = query.Where(Filter);

        ApplySorting(query);

        ApplyPageing(query);

        return query;

    }


    protected void AddFilter(Expression<Func<TType, bool>> prod)
    {
        Filter = prod;
    }

    protected void And(Expression<Func<TType, bool>> prod)
    {
        var parameter = Expression.Parameter(typeof(TType), "item");
        var body = Expression
            .AndAlso
            (
                Expression.Invoke(Filter, parameter),
                Expression.Invoke(prod, parameter)
            );
        Filter = Expression.Lambda<Func<TType, bool>>(body, parameter);
    }


    protected void AndNot(Expression<Func<TType, bool>> prod)
    {

        var parameter = Expression.Parameter(typeof(TType), "item");
        var notExpression = Expression.Not(Expression.Invoke(prod, parameter));
        var body = Expression.AndAlso(Expression.Invoke(Filter, parameter), notExpression);
        Filter = Expression.Lambda<Func<TType, bool>>(body, parameter);
    }


    protected void Or(Expression<Func<TType, bool>> prod)
    {

        var parameter = Expression.Parameter(typeof(TType), "item");
        var body = Expression
            .OrElse
            (
                Expression.Invoke(Filter, parameter),
                Expression.Invoke(prod, parameter)
            );
        Filter = Expression.Lambda<Func<TType, bool>>(body, parameter);

    }


    protected void OrNot(Expression<Func<TType, bool>> prod)
    {

        var parameter = Expression.Parameter(typeof(TType), "item");
        var notExpression = Expression.Not(Expression.Invoke(prod, parameter));
        var body = Expression.OrElse(Expression.Invoke(Filter, parameter), notExpression);
        Filter = Expression.Lambda<Func<TType, bool>>(body, parameter);

    }

    protected void Not(Expression<Func<TType, bool>> prod)
    {
        var parameter = prod.Parameters[0];
        var body = Expression.Not(prod.Body);
        Filter = Expression.Lambda<Func<TType, bool>>(body, parameter);
    }


    #endregion


    #region Help method

    private void ReadMethod()
    {
        _includeMethods =
        (
            from method in GetType().GetMethods()
            where !method.IsSpecialName && method.DeclaringType == GetType()
            select method
        ).ToList();
    }

    private IQueryable<TType> ApplyPageing(IQueryable<TType> query)
    {
        PageIndex = PageIndex > 0 ? PageIndex : 1;
        PageSize = PageSize > 0 ? PageSize : 1;
        query = query.Skip((PageIndex - 1) * PageSize).Take(PageSize);
        return query;
    }

    private IQueryable<TType> ApplySorting(IQueryable<TType> query)
    {
        query = SortDirection == Direction.Asc
            ? query.OrderBy(SortColumn)
            : query.OrderByDescending(SortColumn);
        return query;
    }


    #endregion



}

public abstract class FilterBase<TType> : BasePage<TType>
    where TType : Entity

{
    protected Expression<Func<TType, bool>> Filter;
    protected bool BackEndFilter { get; set; } = false;
    protected List<string> FilterBy { get; set; } = new List<string>();
    protected bool FilterByAll { get; set; } = false;
    protected abstract void ApplyFilter();


}

public class BasePage<TType> where TType : Entity
{
    public int PageIndex { get; set; } = DefaultFilterValue.PageIndex;
    public int PageSize { get; set; } = DefaultFilterValue.PageSize;
    public Expression<Func<TType, object>> SortColumn { get; set; } = DefaultFilterValue.SortColumn<TType>();
    public Direction SortDirection { get; set; } = DefaultFilterValue.SortDirection;
}