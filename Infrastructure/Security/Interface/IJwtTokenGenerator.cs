using Domain.Entities;
using System.Security.Claims;

namespace Infrastructure.Security.Interface;

public interface IJwtTokenGenerator
{

    string GenerateJwt(User user);

    Task<bool> ValidateTokenAsync(string token);
}