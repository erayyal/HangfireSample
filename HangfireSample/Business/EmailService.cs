using System.Net;
using System.Net.Mail;
using HangfireSample.Models;

namespace HangfireSample.Business;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<EmailResponseModel> SendEmail()
    {
        try
        {
            var fromAddress = new MailAddress(_configuration.GetSection("FromAddress").Value, "From Address Name");
            var fromPassword = _configuration.GetSection("Password").Value;

            var toReceiver = new MailAddress("Receiver Mail Address", "Receiver Name");

            var smtp = new SmtpClient
            {
                Host = _configuration.GetSection("Host").Value,
                Port = Convert.ToInt32(_configuration.GetSection("Port").Value),
                EnableSsl = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var messageToReceiver = new MailMessage(fromAddress, toReceiver)
            {
                IsBodyHtml = true,
                Subject = "Email Subject!",
                Body = "Email body"
            };
            smtp.Send(messageToReceiver);
            return Task.FromResult(new EmailResponseModel { Status = true, StatusText = "Email sent successfully" });
        }
        catch (Exception ex)
        {
            return Task.FromResult(new EmailResponseModel { Status = false, StatusText = ex.Message });
        }
    }
}