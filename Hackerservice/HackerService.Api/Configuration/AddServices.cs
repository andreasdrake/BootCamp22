using HackerService.Krypto;
namespace HackerService.Api.Configuration;

public static class Services
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IKrypto, Krypto.Krypto>();
    }
}


