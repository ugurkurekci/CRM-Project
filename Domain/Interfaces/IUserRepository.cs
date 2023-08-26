using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{

    Task<User?> FindByEmailAsync(string email);

}