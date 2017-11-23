using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace ITDAngularJS
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message, string ContactEmail, string ContactPassword, int SmtpPort, string SmtpServer)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(email, ContactEmail));
            emailMessage.To.Add(new MailboxAddress("Me", ContactEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(SmtpServer, SmtpPort, false);
                await smtpClient.AuthenticateAsync(ContactEmail, ContactPassword);
                await smtpClient.SendAsync(emailMessage);

                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}