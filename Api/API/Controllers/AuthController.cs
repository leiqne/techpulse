using System.Net.Mime;
using API.Entities.Users.Interfaces;
using API.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/auth")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthController(IAccountAuthService accountAuthService) : ControllerBase
{
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(SignInResource signInResource)
    {
        var authenticatedUser = await accountAuthService.Handle(signInResource);
        var resource = "User ID: " + authenticatedUser.user.Id + " Token: " + authenticatedUser.token;
        return Ok(resource);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(SignUpResource signUpResource)
    {
        var signup = await accountAuthService.Handle(signUpResource);
        if (signup is null) return BadRequest();
        return Ok();
    }
}