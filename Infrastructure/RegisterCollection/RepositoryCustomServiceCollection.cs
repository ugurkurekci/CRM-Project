using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Security;
using Infrastructure.Security.Interface;
using Infrastructure.Security.Service;
using Infrastructure.TechnicalServices.Caching;
using Infrastructure.TechnicalServices.Emailing;
using Infrastructure.TechnicalServices.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.RegisterCollection;

public static class RepositoryCustomServiceCollection
{
    public static IServiceCollection AddRepositoryCustomServices(this IServiceCollection services)
    {

        IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ProjectDbContext>(options =>
            options.UseSqlServer("Server=DESKTOP-3KUC0E9;Database=WURSOFT;TrustServerCertificate=True;Trusted_Connection=True"));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ILogger, Logger>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<JwtSettings>();
        services.AddScoped<IMemoryCache, MemoryCache>();
        services.AddScoped<ICacheManager, CacheManager>();


        return services;
    }
}
