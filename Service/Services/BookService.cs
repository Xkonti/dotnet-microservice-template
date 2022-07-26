using Microsoft.EntityFrameworkCore;
using Service.Data;
using Service.Models;

namespace Service.Services;

public class BookService : IBookService
{
    private readonly DataContext _context;

    public BookService(DataContext context)
    {
        _context = context;
    }

    public async Task<Book?> GetBookById(Guid id)
    {
        return await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Book>> GetBooksByTitle(string title)
    {
        return await _context.Books
            .Where(b => b.Title == title.Trim())
            .ToListAsync();
    }
}