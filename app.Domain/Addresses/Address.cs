using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;


namespace app.Domain.Addresses;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class Address : Entity
{
    public virtual Street? Street { get; set; }

    public string HouseNumber { get; set; }

    public int ZipCode { get; set; }


    internal class Configuration : ConfigureTable<Address>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(a => a.HouseNumber).IsRequired().HasMaxLength(100)
                .HasDefaultValue("There is no house number");

            Builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(50)
                .HasDefaultValue(0000);
        }

    }


}

