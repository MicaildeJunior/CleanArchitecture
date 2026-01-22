using FluentValidation;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
                .WithMessage("O nome é obrigatório.")
            .MinimumLength(3)
                .WithErrorCode("O nome deve ter no mínimo 3 caracteres.")
            .MaximumLength(100)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
                .WithMessage("O email é obrigatório.")
            .MaximumLength(50)
                .WithMessage("O email deve ter no máximo 50 caracteres.")
            .EmailAddress()
                .WithMessage("O formato do e-mail é inválido (deve conter @ e um domínio válido).");
    }
}
