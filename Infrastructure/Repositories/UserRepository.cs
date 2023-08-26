using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private readonly ProjectDbContext _dbContext;

    public UserRepository(ProjectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

}