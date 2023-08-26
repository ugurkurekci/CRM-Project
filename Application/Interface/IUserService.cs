using Infrastructure.Security;

namespace Application.Interface;

public interface IUserService
{
    Task<AuthenticationResult> LoginAsync(string email, string password);

    Task<bool> ValidateAsync(string token);

}