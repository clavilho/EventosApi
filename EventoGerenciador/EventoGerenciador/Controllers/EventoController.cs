using EventoGerenciador.Application.Interface;
using EventoGerenciador.Domain.RequestEntities;
using Microsoft.AspNetCore.Mvc;

namespace EventoGerenciador.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventosService eventoService;

    public EventoController(IEventosService eventoService)
    {
        this.eventoService = eventoService;
    }

    [HttpPost]
    [Route("{idEvento}/registrar")]
    public IActionResult RegistrarParticipanteNoEvento([FromRoute] Guid idEvento, [FromBody] RequestEvent evento)
    {
        eventoService.RegistrarParticipanteNoEvento(idEvento, evento);

        return Ok();
    }

}
