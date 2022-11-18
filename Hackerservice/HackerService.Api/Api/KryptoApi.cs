using FluentValidation;
using HackerService.Api.Models;
using HackerService.Krypto;
using Microsoft.AspNetCore.Mvc;

namespace HackerService.Api;

public static class KryptoApi
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/encrypt", Encrypt)
            .WithName("Encrypt");

        routes.MapPost("/decrypt", Decrypt)
            .WithName("Decrypt");

        routes.MapPost("/error", () => {
            return Results.Problem("An error occurred.", statusCode: 500);
            //TODO: Add logging;
            }).ExcludeFromDescription();

        return routes;
    }

    public static IResult Encrypt([FromBody] EncryptRequest request,
        [FromServices] IValidator<EncryptRequest> validator, [FromServices] IKrypto krypto)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        return Results.Ok(krypto.Encrypt(request.Value));
    }

    public static IResult Decrypt([FromBody] DecryptRequest request,
        [FromServices] IValidator<DecryptRequest> validator,
        [FromServices] IKrypto krypto)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }
        return Results.Ok(krypto.Decrypt(request.Value));
    }
}