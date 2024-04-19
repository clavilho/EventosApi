using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Interface;

public interface IEventosService
{
    Task RegistrarEvento(EventoModel request);
    Task<EventoModel> BuscarEventoPorId(Guid idEvento);
}
