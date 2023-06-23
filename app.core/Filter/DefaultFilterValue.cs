using app.core.EntityAndDtoStructure.EntityStructure;
using System.Linq.Expressions;

namespace App.core.Filter;

public static class DefaultFilterValue
{
    public static Expression<Func<TType, object>> SortColumn<TType>() where TType : Entity => x => x.Id;
    public const Direction SortDirection = Direction.Asc;
    public const int PageSize = 10;
    public const int PageIndex = 1;
}