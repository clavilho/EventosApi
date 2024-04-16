using Dapper;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Repository;
using System.Data.SqlClient;
namespace EventoGerenciador.Infrastructure;

public class SqlRepository : ISqlRepository
{
    public async Task pegarQualquerCoisa()
    {
        var connectionString = "Server=localhost;Database=BancoDeEventos;Trusted_Connection=True;";
        var sqlCommando = "SELECT top 10 * FROM Evento";

        try
        {
            using (var db = new SqlConnection(connectionString))
            {
                await db.OpenAsync();
                var evento = await db.QueryAsync<Evento>(sqlCommando);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
       

    }
}
