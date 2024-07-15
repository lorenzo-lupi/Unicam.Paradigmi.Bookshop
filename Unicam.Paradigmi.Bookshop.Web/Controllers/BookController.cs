using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.Factories;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;
using Unicam.Paradigmi.Bookshop.Application.Models.Responses;

namespace Unicam.Paradigmi.Bookshop.Web.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateBookAsync(CreateBookRequest request)
    {
        var result = await _bookService.CreateBookAsync(request.ToEntity(), request.CategoryIds);

        var response = new CreateBookResponse
        {
            BookDto = BookDtoFactory.FromBook(result)
        };
        return Ok(ResponseFactory.WithSuccess(response));
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateBookAsync(UpdateBookRequest request)
    {
        var result = await _bookService.UpdateBookAsync(request.ToDto(), request.CategoryIds);
        var response = new CreateBookResponse
        {
            BookDto = BookDtoFactory.FromBook(result)
        };
        return Ok(ResponseFactory.WithSuccess(response));
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteBookAsync(DeleteBookRequest request)
    {
        var result = await _bookService.DeleteBookAsync(request.Id);
        var deleteBookResponse = new DeleteBookResponse()
        {
            Result = result
        };
        
        if (result)
        {
            return Ok(deleteBookResponse);
        }

        return BadRequest(ResponseFactory.WithError("Book not found"));
    }

    [HttpPost]
    [Route("get")]
    public async Task<IActionResult> GetBookAsync(GetBookRequest request)
    {
        var result = await _bookService.GetBookAsync(request.Page, request.PageSize, request.BookName,
            request.PublicationDate, request.Author);
        var response = new GetBookResponse
        {
            Books = result.Select(BookDtoFactory.FromBook).ToList()
        };
        return Ok(ResponseFactory.WithSuccess(response));
    }
}