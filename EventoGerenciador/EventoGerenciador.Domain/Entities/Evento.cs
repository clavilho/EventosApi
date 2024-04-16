using System.ComponentModel.DataAnnotations.Schema;

namespace EventoGerenciador.Domain.Entities;

[Table("Evento")]
public class Evento
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Detalhes { get; set; }
    public string Slug { get; set; }
    public int Maximo_Participantes { get; set; }
}
