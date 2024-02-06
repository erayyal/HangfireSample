using Hangfire;

namespace HangfireSample.Hangfire;

public class HangfireRun
{
    public static void RunJob()
    {
        RecurringJob.AddOrUpdate<IHangfireJob>("Sends Daily Emails", x => x.SendEmail(), "45 17 * * *");
    }
}