using app.Domain.Humans.Customers;
using App.core;
using Microsoft.EntityFrameworkCore;

namespace App.Data.IncludeConfig;
// ReSharper disable once ClassNeverInstantiated.Global
public class CustomerInclude : BaseInclude<Customer>
{
    public CustomerInclude()
    {
        IncludeAll = true;
    }

    public IQueryable<Customer> Human() => Query.Include(nav => nav.HumanInfo);
    public IQueryable<Customer> Tax() => Query.Include(nav => nav.Tax);
    public IQueryable<Customer> CreditTerms() => Query.Include(nav => nav.CreditTerms);
    public IQueryable<Customer> Attachment() => Query.Include(nav => nav.Attachment);
    public IQueryable<Customer> Person()
        => Query
        .Include(c => c.PersonInfo!.Phone)
        .Include(c => c.PersonInfo!.Email)
        .Include(nav => nav.PersonInfo!.Address!.Street!.City!.Country);
    public IQueryable<Customer> Company() => Query
        .Include(nav => nav.Company!.Tax)
        .Include(nav => nav.Company!.Address!.Street!.City!.Country);
}
