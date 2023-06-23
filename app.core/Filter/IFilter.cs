using app.core.EntityAndDtoStructure.EntityStructure;
using System.Linq.Expressions;

namespace App.core.Filter;

public interface IFilter<TType> : IPage, ISort<TType> where TType : Entity
{
    public IQueryable<TType> ApplyFilter(IQueryable<TType> query);
}

public interface IPage
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

}

public interface ISort<TType> where TType : Entity
{
    public Expression<Func<TType, object>> SortColumn { get; set; }
    public Direction SortDirection { get; set; }
}