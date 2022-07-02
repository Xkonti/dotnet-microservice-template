namespace Service.Data;

public class AuditableEntity : BaseEntity, IAuditable
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}