using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;

namespace app.Domain.humans;

public class Human : Entity

{
    public string Name { get; set; }

    public int? Age { get; set; }

    public Gender? Gender { get; set; }



    internal class Configuration : ConfigureTable<Human>
    {
        protected override void ConfigureCustomizations()
        {
            Builder.Property(p => p.Name).IsRequired().HasMaxLength(500);

            Builder.HasIndex(p => p.Name);
        }
    }


}