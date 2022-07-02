namespace Service.Models.Dtos;

public class BookReadDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public int Pages { get; set; }
}