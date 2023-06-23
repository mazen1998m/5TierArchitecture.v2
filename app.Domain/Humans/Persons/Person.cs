using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using app.Domain.Addresses;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Humans.Persons;


public class Person : Entity
{
    public int CivilNumber { get; set; }
    public virtual Address? Address { get; set; }

    public virtual Phone? Phone { get; set; }

    public virtual Email? Email { get; set; }

    internal class Configuration : ConfigureTable<Person>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.CivilNumber).HasMaxLength(100)
                .IsRequired().HasDefaultValue(000000);

            Builder.HasIndex(p => p.CivilNumber);
        }
    }


}
