namespace app.core.EntityAndDtoStructure.EntityStructure;

public abstract class Entity : EntityBase, IDBase
{
    public virtual int Id { get; set; }

}
