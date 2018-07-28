using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FitHub.Services
{
    public class SendGridMessageService : IMessageService
    {
        public async Task Send(string email, string subject, string message)
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@fithub.com", "FitHub Administrator");
            var mySubject = subject;
            var to = new EmailAddress(email, email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            /*
            var emailMessage = new SendGrid.SendGridMessage();
            emailMessage.AddTo(email);
            emailMessage.Subject = subject;
            emailMessage.From = new System.Net.Mail.MailAddress("senderEmailAddressHere@senderDomainHere", "info");
            emailMessage.Html = message;
            emailMessage.Text = message;

            var transportWeb = new SendGrid.Web("PUT YOUR SENDGRID KEY HERE");
            try
            {
                await transportWeb.DeliverAsync(emailMessage);
            }
            catch (InvalidApiRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Errors.ToList().Aggregate((allErrors, error) => allErrors += ", " + error));
            }
            */
        }
    }
}
