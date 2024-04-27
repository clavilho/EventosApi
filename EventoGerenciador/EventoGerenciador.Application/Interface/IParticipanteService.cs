using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Model;

namespace EventoGerenciador.Application.Interface;

public interface IParticipanteService
{
    Task<ParticipanteModel> RegistrarParticipante(ParticipanteModel participante);
    Task<IEnumerable<ParticipanteModel>> BuscarParticipantesDoEvento(Guid idEvento);
}
