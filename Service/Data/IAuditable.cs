namespace Service.Data;

public interface IAuditable
{
    public DateTime CreatedOn { get; set; }
    
    public DateTime? UpdatedOn { get; set; }
}