namespace EventoGerenciador.Domain.Entities;

public class Participante
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Email { get; set; }
    public Guid Event_Id { get; set; }
    public DateTime DataCriacao { get; set; }
    //public CheckIn? CheckIn { get; set; }
}
