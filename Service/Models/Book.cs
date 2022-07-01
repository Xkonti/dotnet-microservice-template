using Service.Data;

namespace Service.Models;

public class Book : AuditableEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int Pages { get; set; }
}