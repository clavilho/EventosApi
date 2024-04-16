using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Interface;

public interface IEventosService
{
    Task RegistrarEvento(Guid idEvento, RequestEvent request);
}
