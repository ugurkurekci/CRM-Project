namespace Infrastructure.Security;

public class JwtSettings
{
    // random secret key

    public string Secret { get; set; } = "super secret key";
    public string Issuer { get; set; } = "localhost";
    public string Audience { get; set; } = "localhost";
    public int ExpiryInDays { get; set; } = 1;

}