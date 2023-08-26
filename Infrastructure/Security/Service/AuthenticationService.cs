using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Security.Interface;

namespace Infrastructure.Security.Service;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> AuthenticateAsync(string email, string password)
    {

        User user = await _userRepository.FindByEmailAsync(email);
        if (user == null || !user.ValidatePassword(password))
        {
            return new AuthenticationResult("Invalid username or password.");
        }

        string token = _jwtTokenGenerator.GenerateJwt(user);
        if (token == null)
        {
            return new AuthenticationResult("Unable to generate token.");
        }

        return new AuthenticationResult(token);

    }

}