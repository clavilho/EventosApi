using Dapper;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Infrastructure.Sql;

namespace EventoGerenciador.Infrastructure;

public class ParticipanteRepository : BaseRepositoy<Participante>, IParticipanteRepository
{
    public async Task CadastrarParticipante(Participante participante)
    {
        try
        {
            var parametros = new DynamicParameters(); 
            parametros.Add("@id", participante.Id);
            parametros.Add("@nome", participante.Nome);
            parametros.Add("@email", participante.Email);
            parametros.Add("@eventoId", participante.Event_Id);
            parametros.Add("@dataCriacao", participante.DataCriacao);

            await InsertAsync(ParticipanteSql.InserirParticipante, parametros);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
