using Dapper;
using EventoGerenciador.Domain.Repository;
using System.Data.SqlClient;

namespace EventoGerenciador.Infrastructure;

public class BaseRepositoy<TEntity> : IBaseRepository<TEntity> where TEntity : class
{


    private SqlConnection ObterConexao()
    {
        var connectionString = "Server=localhost;Database=BancoDeEventos;Trusted_Connection=True;";

        return new SqlConnection(connectionString);
    }

    public virtual async Task<T> ObterPorId<T>(string query, DynamicParameters parametros)
    {
        using (var db = ObterConexao())
        {
            return await db.QueryFirstOrDefaultAsync<T>(query, parametros);
        }
    }

    public async Task<IEnumerable<T>> ListarAsync<T>(string query, DynamicParameters? parametros = null)
    {
        using (var db = ObterConexao())
        {
            return await db.QueryAsync<T>(query, parametros);
        }
    }

    public async Task<int> UpdateAsync(string query, DynamicParameters? parametros = null)
    {
        using (var db = ObterConexao())
        {
            return await db.ExecuteAsync(query, parametros);
        }
    }

    public async Task<int> InsertAsync(string query, DynamicParameters? parametros = null)
    {
        using (var db = ObterConexao())
        {
            return await db.ExecuteAsync(query, parametros);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
