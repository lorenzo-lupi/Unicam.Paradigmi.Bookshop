using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.Factories;
using Unicam.Paradigmi.Bookshop.Application.Models.Requests;
using Unicam.Paradigmi.Bookshop.Application.Models.Responses;

namespace Unicam.Paradigmi.Bookshop.Web.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/[controller]")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTokenAsync(CreateTokenRequest createTokenRequest)
    {
        var token = await _tokenService.CreateTokenAsync(createTokenRequest.Email, createTokenRequest.Password);
        var createTokenResponse = new CreateTokenResponse
        {
            Token = token
        };

        return Ok(ResponseFactory.WithSuccess(createTokenResponse));
    }
}