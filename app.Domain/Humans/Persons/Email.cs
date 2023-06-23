using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;
using Microsoft.EntityFrameworkCore;

namespace app.Domain.Humans.Persons;

public class Email : Entity
{

    public string EmailAddress { get; set; }

    internal class Configuration : ConfigureTable<Email>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.EmailAddress)
                .IsRequired().HasDefaultValue("There is no email");
        }
    }


}