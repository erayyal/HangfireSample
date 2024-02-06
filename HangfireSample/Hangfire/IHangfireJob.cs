namespace HangfireSample.Hangfire;

public interface IHangfireJob
{
    Task SendEmail();
}