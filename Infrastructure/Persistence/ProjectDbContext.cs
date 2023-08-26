using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

// Entity Framework Core kullanarak veritabanı işlemlerini yönetecek olan DbContext sınıfını içerir.
// DbSet'ler ve ilişkiler burada tanımlanır.

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectDbContext).Assembly);
    }

}