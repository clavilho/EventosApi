namespace EventoGerenciador.Infrastructure.Sql;

public class EventoSql
{
    public const string BuscarEventoPorId = @"SELECT * FROM Evento WHERE id = @id";

    public const string INSERIR_EVENTO = @"INSERT INTO Evento
                                               (Id
                                               ,Titulo
                                               ,Detalhes
                                               ,Slug
                                               ,Maximo_Participantes)
                                            VALUES
                                                (@Id
                                                ,@Titulo
                                                ,@Detalhes
                                                ,@Slug
                                                ,@Maximo_Participantes)";

    public const string BUSCAR_TODOS_EVENTOS = "SELECT * FROM Evento";
}
