using Hangfire;
using Hangfire.MemoryStorage;
using HangfireSample.Business;
using HangfireSample.Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(config => config
     .UseMemoryStorage());

builder.Services.AddScoped<IHangfireJob, HangfireJob>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

app.UseHangfireServer();

app.UseHangfireDashboard();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

HangfireRun.RunJob();

app.Run();