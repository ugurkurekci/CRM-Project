using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Emailing;

public class EmailSender
{

    private readonly SmtpClient _smtpClient;
    private readonly EmailSettings _emailSettings;

    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
        _smtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
        {
            Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password),
            EnableSsl = _emailSettings.EnableSsl
        };
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {

        MailMessage? mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        mailMessage.To.Add(email);

        await _smtpClient.SendMailAsync(mailMessage);

    }

}