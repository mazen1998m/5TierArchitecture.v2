using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Taxes;

public class Tax : Entity
{
    public string TaxCode { get; set; }
    internal class Configuration : ConfigureTable<Tax>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.TaxCode)
                .IsRequired().HasDefaultValue("There is no tax code");

            Builder.HasIndex(p => p.TaxCode);
        }
    }
}