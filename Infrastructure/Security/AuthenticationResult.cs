using Domain.Entities;

namespace Infrastructure.Security;

public record AuthenticationResult(string? Token);