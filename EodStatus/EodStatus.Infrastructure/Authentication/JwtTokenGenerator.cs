using System.Text;
using System.Security.Claims;
using EodStatus.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using EodStatus.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace EodStatus.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        //JwtSecurityTokenHandler => writeToken =>
        //JwtSecurityToken 
        // - Issuer
        // - Audience
        // - Claims
        // - Expires
        // - symmetricSecurityKey => secret (in bytes)
        // - SigningCredentials => secret (in bytes), SecurityAlgorithm

        var claimsList = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var secretInBytes = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
        var symmetricSecurityKey = new SymmetricSecurityKey(secretInBytes);

        var jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claimsList,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
