namespace app.core.EntityAndDtoStructure;

public abstract class SuperBase
{
    public virtual DateTime? CreatedDate { get; set; }
    public DateTime? UpDateDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpDateBy { get; set; }
    public string? Description { get; set; }


}