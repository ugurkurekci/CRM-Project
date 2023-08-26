namespace Infrastructure.ServiceIntegrations;

// Dış hizmet entegrasyonları için ilgili sınıfları içerir.
// Örneğin, bir ödeme servisi veya e-posta gönderme servisi entegrasyonu burada yer alabilir.

public class PaymentService
{

    public void Pay()
    {
        // Ödeme işlemleri
    }

    public void Refund()
    {
        // İade işlemleri
    }

    public void Cancel()
    {
        // İptal işlemleri
    }

    public void PayWithSavedCard()
    {
        // Kayıtlı kart ile ödeme işlemleri
    }

    public void PayWithSavedCardAndCvv()
    {
        // Kayıtlı kart ve cvv ile ödeme işlemleri
    }

}