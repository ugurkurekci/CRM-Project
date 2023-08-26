using Application.Interface;
using Infrastructure.Security;
using Infrastructure.Security.Interface;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(IAuthenticationService authenticationService, IJwtTokenGenerator jwtTokenGenerator)
    {
        _authenticationService = authenticationService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {

        AuthenticationResult? authenticationResult = await _authenticationService.AuthenticateAsync(email, password);
        if (authenticationResult == null)
        {
            throw new Exception("Invalid credentials");
        }
        return authenticationResult;
    }

    public async Task<bool> ValidateAsync(string token)
    {
        return await _jwtTokenGenerator.ValidateTokenAsync(token);
    }
}