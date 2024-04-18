using Dapper;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Domain.RequestEntities;
using EventoGerenciador.Infrastructure.Sql;
using System.Data.SqlClient;
namespace EventoGerenciador.Infrastructure;

public class EventoRepository : BaseRepositoy<Evento>, IEventoRepository
{
    public async Task<Evento> PegarEventoPorId(Guid id)
    {
        try
        {
            var parametros = new DynamicParameters();
            parametros.Add("@id", id);
            var evento = await ObterPorId<Evento>(EventoSql.BuscarEventoPorId, parametros);
            return evento;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public async Task RegistrarParticipanteNoEvento(Guid id, RequestEvent participanteEvento)
    {
        try
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nome", participanteEvento.Name);
            parametros.Add("@email", participanteEvento.Email);
            parametros.Add("@eventoId", id);
            parametros.Add("@dataCriacao", DateTime.Now);
            parametros.Add("@id", Guid.NewGuid());

            await InsertAsync(ParticipanteSql.InserirParticipante, parametros);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
