using Domain.Entities;
using Infrastructure.Security.Interface;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security.Service;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string GenerateJwt(User user)
    {

        List<Claim> claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim("email", user.Email)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime expires = DateTime.UtcNow.AddDays(_jwtSettings.ExpiryInDays);

        JwtSecurityToken? token = new JwtSecurityToken(
                       _jwtSettings.Issuer,
                       _jwtSettings.Audience,
                       claims,
                       expires: expires,
                       signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    public Task<bool> ValidateTokenAsync(string token)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = _jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = _jwtSettings.Audience,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        return Task.FromResult(validatedToken != null);

    }
}