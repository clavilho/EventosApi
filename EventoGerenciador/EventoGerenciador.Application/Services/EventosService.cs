using EventoGerenciador.Application.Interface;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Services
{
    public class EventosService : IEventosService
    {
        private readonly ISqlRepository sqlRepository;


        public EventosService(ISqlRepository sqlRepository)
        {
            this.sqlRepository = sqlRepository;
        }

        public async Task RegistrarEvento(Guid idEvento, RequestEvent request)
        {
            await sqlRepository.pegarQualquerCoisa();

        }


        private void ValidarEvento(Guid idEvento, RequestEvent request)
        {
            sqlRepository.pegarQualquerCoisa();
            //Server=localhost;Database=master;Trusted_Connection=True;
        }
    }
}
