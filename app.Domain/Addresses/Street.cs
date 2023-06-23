using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Addresses;

public class Street : Entity
{
    public string Name { get; set; }
    public string? Number { get; set; }

    public virtual City? City { get; set; }

    internal class Configuration : ConfigureTable<Street>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.Name).HasMaxLength(255)
                .IsRequired().HasDefaultValue("There is no name");

            Builder.Property(p => p.Number).HasMaxLength(255)
                .IsRequired().HasDefaultValue("There is no number");
        }
    }
}