using Application.Interface;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.RegisterCollection;

public static class ApplicationCustomServiceCollection
{
    public static IServiceCollection AddServicesCustomServices(this IServiceCollection services)
    {
        // mapper

        return services
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining(typeof(IAssemblyMarker))
                .AddAutoMapper(typeof(IAssemblyMarker));
    }
}