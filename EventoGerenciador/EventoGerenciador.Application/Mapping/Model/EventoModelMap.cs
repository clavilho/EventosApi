using AutoMapper;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Mapping.Model
{
    public class EventoModelMap : Profile
    {
        public EventoModelMap()
        {
            CreateMap<EventoModel, Evento>()
                .ConstructUsing(evento => EventoModel.MapRequestEventoModel(evento));

            CreateMap<Evento, EventoModel>()
                .ConstructUsing(evento => EventoModel.MapRequestEvent(evento));
        }
    }
}
