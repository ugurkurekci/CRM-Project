namespace Infrastructure.ServiceIntegrations;

// Dış hizmet entegrasyonları için ilgili sınıfları içerir.

public class SmsService
{

    public bool SendSmsAsync(string phoneNumber, string message)
    {
        return true;
    }

}