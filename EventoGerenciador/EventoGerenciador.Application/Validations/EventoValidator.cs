using EventoGerenciador.Domain.RequestEntities;
using FluentValidation;

namespace EventoGerenciador.Application.Validations;

public class EventoValidator : AbstractValidator<EventoModel>
{
    public EventoValidator()
    {
        RuleFor(request => request.Maximo_Participantes).GreaterThan(0).WithMessage("O numero maximo de participantes é invalido");
        RuleFor(request => request.Titulo).NotEmpty().NotNull().WithMessage("O evento precisa ter um titulo.");
        RuleFor(request => request.Detalhes).NotNull().NotNull().WithMessage("O evento precisa de ter uma descrição.");
    }
}
