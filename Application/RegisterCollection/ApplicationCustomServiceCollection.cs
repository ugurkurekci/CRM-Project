using Application.Interface;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Security.Interface;
using Infrastructure.Security.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.RegisterCollection;

public static class ApplicationCustomServiceCollection
{
    public static IServiceCollection AddServicesCustomServices(this IServiceCollection services)
    {

        return services
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining(typeof(IAssemblyMarker))
                .AddAutoMapper(typeof(IAssemblyMarker));
    }
}