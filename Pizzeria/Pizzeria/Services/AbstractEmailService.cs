using System.Net.Mail;
using System.Net;

namespace Pizzeria.Services
{
    public abstract class AbstractEmailService
    {
        protected abstract string SmtpHost { get; }
        protected abstract int SmtpPort { get; }
        protected abstract bool EnableSsl { get; }
        protected abstract string UserName { get; }
        protected abstract string Password { get; }
        public void SendEmail(string recipientEmail, string recipientName, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(UserName, "Samanta");
            MailAddress toAddress = new MailAddress(recipientEmail, recipientName);

            MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = false // Set to true if the body contains HTML
            };

            SmtpClient smtpClient = new SmtpClient
            {
                Host = SmtpHost,
                Port = SmtpPort,
                EnableSsl = EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(UserName, Password)
            };
            //smtpClient.Send(message);
        }
    }
}
