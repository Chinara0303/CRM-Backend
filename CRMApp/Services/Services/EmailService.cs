using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Services.Services.İnterfaces;
using Services.Helpers.AccountSetting;

namespace Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting _emailSetting;
        public EmailService(EmailSetting emailSetting)
        {
            _emailSetting = emailSetting;
        }
        public void Send(string to, string subject, string html, string from = null)
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _emailSetting.From));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect(_emailSetting.SmtpServer, _emailSetting.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSetting.Username, _emailSetting.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
