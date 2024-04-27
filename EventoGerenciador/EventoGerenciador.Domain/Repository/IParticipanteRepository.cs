using EventoGerenciador.Domain.Entities;

namespace EventoGerenciador.Domain.Repository;

public interface IParticipanteRepository
{
    Task CadastrarParticipante(Participante participante);
}
