namespace Service.Data;

public class AuditableEntity<TId> : BaseEntity<TId>, IAuditable
{
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}