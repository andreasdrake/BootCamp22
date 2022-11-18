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

        return routes;
    }
     
    public static IResult Encrypt([FromBody]string value, [FromServices] IKrypto krypto)
    {
        return Results.Ok(krypto.Encrypt(value));
    }

    public static IResult Decrypt([FromBody] string value, [FromServices] IKrypto krypto)
    {
        return Results.Ok(krypto.Decrypt(value));
    }
}