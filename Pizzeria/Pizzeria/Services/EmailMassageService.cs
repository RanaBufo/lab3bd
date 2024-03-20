using Pizzeria.Models;
using System.Net.Mail;
using System.Net;

namespace Pizzeria.Services
{
    public class EmailMassageService : AbstractEmailService
    {
        protected override string SmtpHost => "smtp.gmail.com";
        protected override int SmtpPort => 587;
        protected override bool EnableSsl => true;
        protected override string UserName => "milly.ili000@gmail.com";
        protected override string Password => "cuvf siiq hgqg erqs";
    }
}
