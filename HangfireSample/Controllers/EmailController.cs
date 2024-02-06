using HangfireSample.Business;
using HangfireSample.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HangfireSample.Controllers;


[ApiController]
[Route("[controller]")]
public class EmailController : Controller
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    [HttpPost("SendEmail")]
    [SwaggerOperation(
        Summary = "Sends email every day with hangfire",
        Description = "Sends email every day with hangfire")]
    public async Task<EmailResponseModel> SendEmail()
    {
        var response = await _emailService.SendEmail();
        return (response);
    }
}