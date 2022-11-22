using EodStatus.Application.Services.Authentication;
using EodStatus.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EodStatus.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var serviceResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var authResponse = new AuthenticationResponse(
            serviceResult.Id,
            serviceResult.FirstName,
            serviceResult.LastName,
            serviceResult.Email,
            serviceResult.Token
        );
        return Ok(authResponse);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var serviceResult = _authService.Login(request.Email, request.Password);

        var authResponse = new AuthenticationResponse(
            serviceResult.Id,
            serviceResult.FirstName,
            serviceResult.LastName,
            serviceResult.Email,
            serviceResult.Token
        );
        return Ok(authResponse);
    }

}
