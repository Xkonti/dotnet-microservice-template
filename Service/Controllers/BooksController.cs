using Mapster;
using Microsoft.AspNetCore.Mvc;
using Service.Models.Dtos;
using Service.Services;

namespace Service.Controllers;

[ApiController]
[Route("api/v1/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("{id:guid}", Name = "GetBookById")]
    public async Task<ActionResult<BookReadDto>> GetBookById(Guid id)
    {
        var book = await _bookService.GetBookById(id);
        if (book is null) return NotFound();
        return Ok(book.Adapt<BookReadDto>());
    }

    [HttpGet("", Name = "GetBooksByTitle")]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooksByTitle([FromQuery] string title)
    {
        var books = await _bookService.GetBooksByTitle(title);
        if (!books.Any()) return NotFound();
        return Ok(books.Adapt<IEnumerable<BookReadDto>>());
    }
}