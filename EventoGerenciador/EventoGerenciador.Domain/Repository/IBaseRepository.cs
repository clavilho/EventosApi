using Dapper;

namespace EventoGerenciador.Domain.Repository;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task<T> ObterPorId<T>(string query, DynamicParameters? parameters = null);
    Task<IEnumerable<T>> ListarAsync<T>(string query, DynamicParameters? parameters = null);
    Task<int> UpdateAsync(string query, DynamicParameters? parameters = null);
    Task<int> InsertAsync(string query, DynamicParameters? parameters = null);
}
