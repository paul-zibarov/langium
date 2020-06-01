using System;
using System.Net;
using System.Net.Mail;

namespace Langium.Domain
{
    public class GmailSMTPHelper
    {
        private readonly string _smtpUrl = "smtp.gmail.com";

        private readonly int _port = 587;

        private readonly string _email = "langium.dictionary@gmail.com";

        private readonly string _password = "Langium123";

        public void SendEmail(string receiverEmail, string emailSubject, string emailBody)
        {
            if (!string.IsNullOrEmpty(receiverEmail) && !string.IsNullOrEmpty(emailBody))
            {
                var client = new SmtpClient(_smtpUrl, _port)
                {
                    Credentials = new NetworkCredential(_email, _password),
                    EnableSsl = true
                };

                client.Send(_email, receiverEmail, emailSubject, emailBody);
            }
        }
    }
}
