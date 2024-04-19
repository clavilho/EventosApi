using EventoGerenciador.Application.Interface;
using EventoGerenciador.Application.Validations;
using EventoGerenciador.Domain.RequestEntities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
    [Route("criarEvento")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public IActionResult RegistrarEvento([FromBody] EventoModel evento)
    {
        try
        {
            EventoValidator validar = new EventoValidator();

            var result = validar.Validate(evento);

            if (!result.IsValid)
            {
                var erros = new List<ValidationFailure>();
                foreach (var item in result.Errors)
                {
                    erros.Add(item);

                }
                return BadRequest(erros);
            }

            eventoService.RegistrarEvento(evento);

            return Ok($"Evento {evento.Titulo} foi criado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("{idEvento}")]
    public async Task<IActionResult> BuscarEventoPorId([FromRoute] Guid idEvento)
    {
        try
        {
            var evento = await eventoService.BuscarEventoPorId(idEvento);

            return Ok(evento);
        }
        catch (Exception)
        {

            throw;
        }
    }

}
