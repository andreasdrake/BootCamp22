using HackerService.Api;
using HackerService.Api.Configuration;
using HackerService.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.AddValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ExceptionLoggerMiddleware>();
app.MapApiEndpoints();
app.Run();
