using EventoGerenciador.Application.Interface;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Domain.RequestEntities;
using System.Net.Mail;

namespace EventoGerenciador.Application.Services
{
    public class EventosService : IEventosService
    {
        private readonly IEventoRepository eventoRepository;


        public EventosService(IEventoRepository eventoRepository)
        {
            this.eventoRepository = eventoRepository;
        }

        public async Task RegistrarParticipanteNoEvento(Guid idEvento, RequestEvent request)
        {
            ValidarEvento(idEvento, request);

            await eventoRepository.RegistrarParticipanteNoEvento(idEvento, request);
        }


        private void ValidarEvento(Guid idEvento, RequestEvent request)
        {
            var evento = eventoRepository.PegarEventoPorId(idEvento);

            if (evento is null)
                throw new Exception("Não é possivel registrar um participante em um evento inexistente");

            if (string.IsNullOrEmpty(request.Name))
                throw new Exception("Não é possivel registrar um participante sem nome");

            EmailEhValido(request.Email);
        }

        private bool EmailEhValido(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch
            {
                throw new Exception("Email não é valido");
            }
        }
    }
}
