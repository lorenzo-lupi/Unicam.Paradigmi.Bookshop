using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.Factories;
using Unicam.Paradigmi.Bookshop.Application.Models.Dtos;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;
using Unicam.Paradigmi.Bookshop.Application.Models.Responses;

namespace Unicam.Paradigmi.Bookshop.Web.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/[controller]")]
public class CategoryController : ControllerBase
{

    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
    {
        var category = await _categoryService.CreateCategoryAsync(request.ToEntity());
        var response = new CreateCategoryResponse()
        {
            CategoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            }
        };
        return Ok(ResponseFactory.WithSuccess(response));
    }
    [HttpDelete]
    [Route("remove")]
    public async Task<IActionResult> RemoveCategoryAsync(RemoveCategoryRequest request)
    {
        var response = new RemoveCategoryResponse();
        response.Result = await _categoryService.RemoveCategoryAsync(request.Id);
        return Ok(ResponseFactory.WithSuccess(response));
    }
}