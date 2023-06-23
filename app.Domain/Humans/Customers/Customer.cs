using app.core.EntityAndDtoStructure.EntityStructure;
using app.Domain.Attachments;
using app.Domain.Companies;
using app.Domain.humans;
using app.Domain.Humans.Persons;
using app.Domain.Taxes;
using App.core.EfCore.TablesConfiguration;

namespace app.Domain.Humans.Customers;
using CreditTerms;

public class Customer : Entity
{
    public virtual Human? HumanInfo { get; set; }

    public virtual Person? PersonInfo { get; set; }
    public int AccountNumber { get; set; }
    public virtual Company? Company { get; set; }
    public virtual Tax? Tax { get; set; }

    public virtual Attachment? Attachment { get; set; }

    public virtual CreditTerms? CreditTerms { get; set; }

    internal class Configuration : ConfigureTable<Customer>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.AccountNumber).IsRequired();

            Builder.HasIndex(p => p.AccountNumber);
        }
    }


}





