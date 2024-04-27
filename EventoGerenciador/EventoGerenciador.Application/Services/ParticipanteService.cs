using AutoMapper;
using EventoGerenciador.Application.Interface;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Model;
using EventoGerenciador.Domain.Repository;

namespace EventoGerenciador.Application.Services;

public class ParticipanteService : IParticipanteService
{
    private readonly IEventoRepository eventoRepository;
    private readonly IParticipanteRepository participanteRepository;
    private readonly IMapper mapper;

    public ParticipanteService(IEventoRepository eventoRepository, IParticipanteRepository participanteRepository, IMapper mapper)
    {
        this.eventoRepository = eventoRepository;
        this.participanteRepository = participanteRepository;
        this.mapper = mapper;
    }
    public async Task<ParticipanteModel> RegistrarParticipante(ParticipanteModel participanteModel)
    {
        try
        {
            var participante = mapper.Map<ParticipanteModel, Participante>(participanteModel);

            var evento = await eventoRepository.PegarEventoPorId(participante.Event_Id);

            if (evento == null)
                throw new Exception("Não existe evento com o id que foi inserido.");

            await participanteRepository.CadastrarParticipante(participante);

            return participanteModel;
        }
        catch (Exception)
        {

            throw;
        }

    }

    public async Task<IEnumerable<ParticipanteModel>> BuscarParticipantesDoEvento(Guid idEvento)
    {
        try
        {
            var evento = await eventoRepository.PegarEventoPorId(idEvento);

            if (evento == null)
                throw new Exception("Não existe evento com o id que foi inserido.");

            var partcipantesModel = new List<ParticipanteModel>();

            var participantes = await participanteRepository.BuscarParticipantesDoEvento(idEvento);

            if (!participantes.Any())
                return new List<ParticipanteModel>();

            foreach (var participante in participantes)
            {
                partcipantesModel.Add(mapper.Map<Participante, ParticipanteModel>(participante));
            }

            return partcipantesModel;

        }
        catch (Exception)
        {

            throw;
        }
    }
}
