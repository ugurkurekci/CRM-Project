﻿using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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
        return services;
    }
}