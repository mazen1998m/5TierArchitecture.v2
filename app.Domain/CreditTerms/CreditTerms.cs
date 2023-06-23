using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;


namespace app.Domain.CreditTerms;


public class CreditTerms : Entity
{
    public double Maximum { get; set; }

    public DateTime? GracePeriod { get; set; }

    internal class Configuration : ConfigureTable<CreditTerms>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.Maximum).IsRequired().HasDefaultValue(0.00);
        }
    }

}