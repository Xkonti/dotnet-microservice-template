using Service.Data;
using StronglyTypedIds;

namespace Service.Models;

[StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)]
public partial struct BookId { }

public class Book : AuditableEntity<BookId>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int Pages { get; set; }
}