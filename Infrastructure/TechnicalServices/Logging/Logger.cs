namespace Infrastructure.TechnicalServices.Logging;

// Uygulama günlüklerini (log) yönetmek için kullanılan sınıfı içerir.
// Log seviyeleri, dosya veya veritabanı kayıtları gibi ayarları burada düzenleyebilirsiniz. 
public class Logger : ILogger
{

    public void Log(string message)
    {

        // Log işlemleri burada yapılır.
        Console.WriteLine(message);

    }

}
