using System.Net.Mail;
using System.Net;

namespace AppGCT.Outros
{
    public class EmailSender : IEmailSender
    {
        private readonly string mailApp;
        private readonly string passApp;

        public EmailSender(string mailApp, string passApp)
        {
            this.mailApp = mailApp;
            this.passApp = passApp;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {

            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(mailApp, passApp);

                using (var mail = new MailMessage(mailApp, email))
                {
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    await client.SendMailAsync(mail);
                }
            }
        }
    }
}
