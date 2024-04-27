using EventoGerenciador.Application.Interface;
using EventoGerenciador.Application.Services;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Infrastructure;
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
        services.AddScoped<IEventosService, EventosService>();
        services.AddScoped<IParticipanteService, ParticipanteService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IEventoRepository, EventoRepository>();
        services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
    }
}
