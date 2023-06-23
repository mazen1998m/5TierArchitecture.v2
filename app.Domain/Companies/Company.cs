using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using app.Domain.Addresses;
using app.Domain.Taxes;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Companies;


public class Company : Entity
{
    public string Name { get; set; }
    public virtual Tax? Tax { get; set; }
    public virtual Address? Address { get; set; }

    internal class Configuration : ConfigureTable<Company>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.Name).HasMaxLength(500)
                .IsRequired().HasDefaultValue("There is no company name");

            Builder.HasIndex(p => p.Name);
        }
    }

}


