using AutoMapper;
using EventoGerenciador.Application.Services;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Repository;
using EventoGerenciador.Domain.RequestEntities;
using EventoGerenciador.Infrastructure;
using Moq;
using Xunit;

namespace EventoGerenciador.Test;

public class EventosServiceTest
{
    private readonly EventosService servico;
    private readonly Mock<IEventoRepository> eventoRepository;
    private readonly Mock<IMapper> mapper;

    public EventosServiceTest()
    {
        eventoRepository = new Mock<IEventoRepository>();
        mapper = new Mock<IMapper>();
        servico = new EventosService(eventoRepository.Object, mapper.Object);
    }

    [Fact]
    public void BuscarEventoPorId_ComIdExistente_RetornaEvento()
    {
        //Arrange
        var evento = new Evento();
        var eventoModel = new EventoModel();

        eventoRepository.Setup(x => x.PegarEventoPorId(It.IsAny<Guid>())).ReturnsAsync(evento);
        //Act
        var result = servico.BuscarEventoPorId(It.IsAny<Guid>());

        //Assert
        eventoRepository.Verify(x => x.PegarEventoPorId(It.IsAny<Guid>()), Times.Once);
        Assert.NotNull(result);
    }
}