using EventoGerenciador.Domain.Entities;

namespace EventoGerenciador.Domain.RequestEntities;

public class EventoModel
{
    public string Titulo { get; set; }
    public string Detalhes { get; set; }
    public int Maximo_Participantes { get; set; }

    public static Evento MapRequestEventoModel(EventoModel eventoModel)
    {
        return new Evento()
        {
            Id = new Guid(),
            Titulo = eventoModel.Titulo,
            Detalhes = eventoModel.Detalhes,
            Maximo_Participantes = eventoModel.Maximo_Participantes,
            Slug = eventoModel.Titulo.ToLower().Replace(" ", "-")
        };
    }

    public static EventoModel MapRequestEvent(Evento evento)
    {
        return new EventoModel
        {
            Titulo = evento.Titulo,
            Detalhes = evento.Detalhes,
            Maximo_Participantes = evento.Maximo_Participantes
        };
    }
}
