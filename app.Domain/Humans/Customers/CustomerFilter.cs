using App.core.Filter;
using System.Linq.Expressions;

namespace app.Domain.Humans.Customers;

using Lambda = Expression<Func<Customer, bool>>;
public class CustomerFilter : Filter<Customer>
{


    public CustomerFilter()
    {
        BackEndFilter = false;
        AddFilter(a => a.Description == "Sales invoice");
        And(x => x.PersonInfo != null && x.PersonInfo.Phone != null && x.PersonInfo.Phone.Number == "5555");
    }


    public string? Number { get; set; }

    private Lambda _Number() => xa => xa.PersonInfo!.Phone!.Number == Number;


    protected override void ApplyFilter()
    {
        AddToFilter(Number is not null, nameof(_Number));
    }
}