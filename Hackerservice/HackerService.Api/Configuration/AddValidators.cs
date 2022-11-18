using FluentValidation;
using HackerService.Api.Models;
using HackerService.Api.Validators;

namespace HackerService.Api.Configuration;

public static class Validators
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<DecryptRequest>, DecryptRequestValidator>();
        services.AddScoped<IValidator<EncryptRequest>, EncryptRequestValidator>();
    }
}
