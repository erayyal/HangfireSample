using HangfireSample.Business;

namespace HangfireSample.Hangfire;

public class HangfireJob : IHangfireJob
{
    private readonly IEmailService _emailService;

    public HangfireJob(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task SendEmail()
    {
        await _emailService.SendEmail();
    }
}