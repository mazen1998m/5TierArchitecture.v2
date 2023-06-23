using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Humans.Persons;

public class Phone : Entity
{
    public string? Number { get; set; }

    internal class Configuration : ConfigureTable<Phone>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.Number).HasMaxLength(50)
                .IsRequired().HasDefaultValue("There is no number");

            Builder.HasIndex(p => p.Number);
        }
    }

}