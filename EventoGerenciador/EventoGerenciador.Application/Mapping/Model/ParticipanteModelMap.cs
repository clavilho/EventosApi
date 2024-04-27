using AutoMapper;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Model;
using EventoGerenciador.Domain.RequestEntities;

namespace EventoGerenciador.Application.Mapping.Model;

public class ParticipanteModelMap : Profile
{
    public ParticipanteModelMap()
    {

        CreateMap<ParticipanteModel, Participante>()
            .ConstructUsing(participante => ParticipanteModel.MapRequestParticipanteModel(participante));
    }
}
