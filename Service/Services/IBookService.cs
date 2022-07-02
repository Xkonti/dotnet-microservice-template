using Service.Models;

namespace Service.Services;

public interface IBookService
{
    Task<Book?> GetBookById(Guid id);
    Task<IEnumerable<Book>> GetBooksByTitle(string title);
}