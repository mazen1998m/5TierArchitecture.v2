using App.core.EfCore.TablesConfiguration;
using app.core.EntityAndDtoStructure.EntityStructure;

namespace app.Domain.Attachments;


public class Attachment : Entity
{

    internal class Configuration : ConfigureTable<Attachment>
    {
        protected override void ConfigureCustomizations()
        {
            base.ConfigureCustomizations();
        }
    }
}