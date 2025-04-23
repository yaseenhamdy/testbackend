using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
//using System.Net.Mail;
using TactiForge.API.Setting;

namespace TactiForge.API.Helper
{
    public class EmailSettings : IMailSettings
    {
        private readonly MailSetting _options;

        public EmailSettings(IOptions<MailSetting> options)
        {
            _options = options.Value;
        }

        public void SendEmail(Email email)
        {
            var mail = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_options.Email),
                Subject = email.Subject
            };

            mail.To.Add(MailboxAddress.Parse(email.To));
            mail.From.Add(new MailboxAddress(_options.DisplayName, _options.Email));

            var builder = new BodyBuilder
            {
                TextBody = email.Body
            };
            mail.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_options.Host, _options.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.Email, _options.Password);
            smtp.Send(mail);
            smtp.Disconnect(true);
        }
    }
}