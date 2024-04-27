using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Model;

namespace EventoGerenciador.Domain.Repository;

public interface IParticipanteRepository
{
    Task CadastrarParticipante(Participante participante);
    Task<IEnumerable<Participante>> BuscarParticipantesDoEvento(Guid idEvento);
}
