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
public class UserController : ControllerBase
{
   private readonly IUserService _userService;
   
   public UserController(IUserService userService)
   {
      _userService = userService;
   }

   [HttpPost]
   [Route("create")]
   public async Task<IActionResult> CreateUser(CreateUserRequest userRequest)
   {
      var user = await _userService.CreateUserAsync(userRequest.ToEntity());
      var userDto = new UserDto(user);
      userDto.Password = "";
      var createUserResponse = new CreateUserResponse()
      {
         UserDto = new UserDto(user)
      };

      return Ok(ResponseFactory.WithSuccess(createUserResponse));
   }


}
