using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
namespace Core.Utilities.Email
{
    public class MailManager : IMailService
    {
        private readonly IConfiguration _configuration;
        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Send(EmailMessage emailMessage)
        {
            var fromAddress = _configuration.GetSection("EmailConfiguration").GetSection("SenderEmail").Value;
            var fromPassword = _configuration.GetSection("EmailConfiguration").GetSection("Password").Value;
            if (!string.IsNullOrEmpty(fromAddress) && !string.IsNullOrEmpty(fromPassword))
            {
                foreach (var toAddress in emailMessage.ToAddresses)
                {
                    //Secret'da
                    var smtp = new System.Net.Mail.SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress, fromPassword),
                    };
                    using var message = new MailMessage(fromAddress, toAddress, toAddress, emailMessage.Content);
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                }
            }
        }
    }
}
