using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.core;


public abstract class BaseInclude<TType> where TType : Entity
{
    protected bool IncludeAll { get; init; }
    private readonly List<MethodInfo> _includeMethods;
    protected IQueryable<TType> Query { get; private set; }


    protected BaseInclude()
    {
        _includeMethods =
        (
            from method in GetType().GetMethods()
            where !method.IsSpecialName && method.DeclaringType == GetType()
            select method
        ).ToList();
    }

    public IQueryable<TType> ApplyInclude(DbSet<TType> table, string[]? include)
    {
        //todo:create includeAll auto and if we dont create include class include all auto

        Query = table.AsQueryable();


        foreach (var method in _includeMethods)
        {
            if (IncludeAll || include!.Contains("IncludeAll"))
            {
                Query = (IQueryable<TType>)method.Invoke(this, null)!;
                continue;

            }

            if (!include!.Any()) break;


            if (include!.Contains(method.Name))
            {
                Query = (IQueryable<TType>)method.Invoke(this, null)!;
            }

        }

        return Query;
    }

}

public interface IInclude<TType> where TType : Entity
{
    public IQueryable<TType> ApplyInclude(DbSet<TType> table, string[]? include);
}