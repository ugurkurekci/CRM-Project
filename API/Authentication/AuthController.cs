using API.Controllers;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Authentication;

public class AuthController : BaseController
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        return Ok(await _userService.LoginAsync(email, password));
    }

    [HttpPost("validate")]
    public async Task<IActionResult> Validate(string token)
    {
        return Ok(await _userService.ValidateAsync(token));
    }

}