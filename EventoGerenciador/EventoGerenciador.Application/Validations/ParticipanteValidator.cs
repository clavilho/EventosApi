using EventoGerenciador.Domain.Model;
using FluentValidation;

namespace EventoGerenciador.Application.Validations;

public class ParticipanteValidator : AbstractValidator<ParticipanteModel>
{
    public ParticipanteValidator()
    {
        RuleFor(participante => participante.Nome).NotEmpty().NotNull().WithMessage("Participante precisa ter um nome");
        RuleFor(participante => participante.Email).NotEmpty().NotNull().WithMessage("É necessario cadastrar um email para o participante.");
        RuleFor(participante => participante.IdEventoCadastrado).NotEmpty().NotNull().WithMessage("Participante precisa ser cadastrar em um evento");
    }
}
