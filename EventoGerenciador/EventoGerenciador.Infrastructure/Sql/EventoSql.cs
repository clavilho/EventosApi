namespace EventoGerenciador.Infrastructure.Sql;

public class EventoSql
{
    public const string BuscarEventoPorId = @"SELECT * FROM Evento WHERE id = @id";
}
