using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Addresses;

public class Country : Entity
{
    public string Name { get; set; }
    public string Code { get; set; }

    internal class Configuration : ConfigureTable<Country>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.Name).HasMaxLength(100)
                .IsRequired().HasDefaultValue("There is no country name");

            Builder.Property(p => p.Code).HasMaxLength(30)
                .IsRequired().HasDefaultValue("There is no code");
        }
    }

}
