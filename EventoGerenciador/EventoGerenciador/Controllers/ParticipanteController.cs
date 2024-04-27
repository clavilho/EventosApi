using EventoGerenciador.Application.Interface;
using EventoGerenciador.Application.Validations;
using EventoGerenciador.Domain.Entities;
using EventoGerenciador.Domain.Model;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace EventoGerenciador.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipanteController : ControllerBase
{
    private readonly IParticipanteService participanteService;

    public ParticipanteController(IParticipanteService participanteService)
    {
        this.participanteService = participanteService;
    }

    [HttpPost]
    [Route("registrarParticipante")]
    public IActionResult RegistrarParticipante([FromBody] ParticipanteModel participante)
    {
        var validacao = new ParticipanteValidator().Validate(participante);

        if (!validacao.IsValid)
        {
            var erros = new List<ValidationFailure>();
            foreach (var item in validacao.Errors)
            {
                erros.Add(item);

            }
            return BadRequest(erros);
        }

        var participanteCadastrado = participanteService.RegistrarParticipante(participante);

        return Created("", participanteCadastrado);
    }

}
