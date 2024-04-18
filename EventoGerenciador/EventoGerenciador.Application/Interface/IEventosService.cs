using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Interface;

public interface IEventosService
{
    Task RegistrarParticipanteNoEvento(Guid idEvento, RequestEvent request);
}
