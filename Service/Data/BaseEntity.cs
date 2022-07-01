namespace Service.Data;

public abstract class BaseEntity
{
    public bool IsDeleted { get; set; }
}

public class BaseEntity<TId> : BaseEntity
{
    public TId Id { get; set; }
}