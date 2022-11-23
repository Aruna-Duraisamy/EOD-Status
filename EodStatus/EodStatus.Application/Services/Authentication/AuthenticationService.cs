using EodStatus.Application.Common.Interfaces.Authentication;

namespace EodStatus.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        //Check if user already exists

        //Create User

        //Create Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);

        return new AuthenticationResult(
            userId,
            FirstName,
            LastName,
            Email,
            token);
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
