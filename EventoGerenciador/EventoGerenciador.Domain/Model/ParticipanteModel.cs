using EventoGerenciador.Domain.Entities;

namespace EventoGerenciador.Domain.Model;

public class ParticipanteModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public Guid IdEventoCadastrado { get; set; }

    public static Participante MapRequestParticipanteModel(ParticipanteModel participanteModel)
    {
        return new Participante
        {
            Id = new Guid(),
            Nome = participanteModel.Nome,
            Email = participanteModel.Email,
            DataCriacao = DateTime.UtcNow,
            Event_Id = participanteModel.IdEventoCadastrado
        };
    }

    public static ParticipanteModel MapRequestParticipante(Participante participante)
    {
        return new ParticipanteModel
        {
            Nome = participante.Nome,
            Email = participante.Email,
            IdEventoCadastrado = participante.Event_Id
        };
    }

}
