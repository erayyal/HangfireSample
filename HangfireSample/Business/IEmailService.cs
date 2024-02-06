using HangfireSample.Models;

namespace HangfireSample.Business;

public interface IEmailService
{
    Task<EmailResponseModel> SendEmail();
}