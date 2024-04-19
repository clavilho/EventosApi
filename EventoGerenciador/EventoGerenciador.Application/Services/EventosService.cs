using AutoMapper;
using EventoGerenciador.Application.Interface;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Services
{
    public class EventosService : IEventosService
    {
        private readonly IEventoRepository eventoRepository;
        private readonly IMapper mapper;

        public EventosService(IEventoRepository eventoRepository, IMapper mapper)
        {
            this.eventoRepository = eventoRepository;
            this.mapper = mapper;
        }

        public async Task<EventoModel> BuscarEventoPorId(Guid idEvento)
        {
            try
            {
                var evento = await eventoRepository.PegarEventoPorId(idEvento);

                if (evento == null)
                    throw new Exception("Esse evento não existe");

                var eventoModel = mapper.Map<Evento, EventoModel>(evento);

                return eventoModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RegistrarEvento(EventoModel request)
        {
            try
            {
                Evento novoEvento = mapper.Map<EventoModel, Evento>(request);
                await eventoRepository.RegistrarEvento(novoEvento);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
