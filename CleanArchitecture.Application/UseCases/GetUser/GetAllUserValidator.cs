using CleanArchitecture.Application.UseCases.GelAllUser;
using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetUser;

public class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator()
    {        
    }
}
