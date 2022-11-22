namespace EodStatus.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            FirstName,
            LastName,
            Email,
            "Token");
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            Email,
            "Token"
        );
    }
}
