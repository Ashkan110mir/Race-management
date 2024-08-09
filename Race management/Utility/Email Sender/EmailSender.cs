
using System.Net.Mail;
using System.Net;

namespace Race_management.Utility.Email_Sender
{
    public class EmailSender : IEmailSender
    {
        public Task Send_Email(string Toemail, string text, string subject, bool ismassagehtml = false)
        {
            using (var client = new SmtpClient())
            {
                var Credential = new NetworkCredential()
                {
                    UserName = "cmstest86",
                    Password = "ugur kxru nold tjgs",
                };

                //client.UseDefaultCredentials = false;
                client.Credentials = Credential;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                client.EnableSsl = true;
                using var massage = new MailMessage()
                {
                    To = { new MailAddress(Toemail) },
                    From = new MailAddress("cmstest86@gmail.com"),
                    Subject = subject,
                    Body = text,
                    IsBodyHtml = ismassagehtml
                };
                client.Send(massage);

            }
            return Task.CompletedTask;
        }
    }
}
