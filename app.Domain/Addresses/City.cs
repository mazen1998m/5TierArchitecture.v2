using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Addresses;

public class City : Entity
{
    public string Name { get; set; }
    public virtual Country? Country { get; set; }

    internal class Configuration : ConfigureTable<City>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(a => a.Name).IsRequired().HasMaxLength(60)
                .HasDefaultValue("There is no city came");
        }
    }
}