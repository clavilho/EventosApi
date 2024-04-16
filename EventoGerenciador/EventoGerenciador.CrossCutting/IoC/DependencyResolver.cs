using Microsoft.Extensions.DependencyInjection;

namespace EventoGerenciador.CrossCutting.IoC;

public static class DependencyResolver
{

    public static void AddDependencyResolver(this IServiceCollection services)
    {
        RegisterApplication(services);
        RegisterRepositories(services);
    }

    private static void RegisterApplication(IServiceCollection services)
    {
        //services.AddScoped<IService,Service>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        //services.AddScoped<IRepository, Repository>();
    }
}
