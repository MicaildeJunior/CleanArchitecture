using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetUser;

public class GetUserValidator : AbstractValidator<GetUserRequest>
{
    public GetUserValidator()
    {        
    }
}
