namespace Infrastructure.Security.Interface;

public interface IAuthenticationService
{

    Task<AuthenticationResult> AuthenticateAsync(string email, string password);

}