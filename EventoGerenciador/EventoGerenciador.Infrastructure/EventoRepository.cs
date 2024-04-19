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
        catch (Exception)
        {
            throw;
        }

    }

    public async Task RegistrarEvento(Evento evento)
    {
        try
        {
            var parametros = new DynamicParameters();
            parametros.Add("@Id", evento.Id);
            parametros.Add("@Titulo", evento.Titulo);
            parametros.Add("@Detalhes", evento.Detalhes);
            parametros.Add("@Slug", evento.Slug);
            parametros.Add("@Maximo_Participantes", evento.Maximo_Participantes);

            await InsertAsync(EventoSql.INSERIR_EVENTO, parametros);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task RegistrarParticipanteNoEvento(Guid id, EventoModel participanteEvento)
    {
        try
        {
            var parametros = new DynamicParameters();
            //parametros.Add("@nome", participanteEvento.Name);
            //parametros.Add("@email", participanteEvento.Email);
            //parametros.Add("@eventoId", id);
            //parametros.Add("@dataCriacao", DateTime.Now);
            //parametros.Add("@id", Guid.NewGuid());

            await InsertAsync(ParticipanteSql.InserirParticipante, parametros);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
