using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Domain.Repository;

public interface IEventoRepository
{
    Task<Evento> PegarEventoPorId(Guid id);
    Task RegistrarParticipanteNoEvento(Guid id, RequestEvent participanteEvento);
}
