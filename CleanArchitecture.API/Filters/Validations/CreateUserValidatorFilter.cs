using CleanArchitecture.Application.UseCases.CreateUser;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.API.Filters.Validations;

public class CreateUserValidatorFilter : IAsyncActionFilter
{
    private readonly IValidator<CreateUserRequest> _validator;

    public CreateUserValidatorFilter(IValidator<CreateUserRequest> validator)
    {
        _validator = validator;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var request = context.ActionArguments.Values.OfType<CreateUserRequest>().FirstOrDefault();
        if (request != null)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

                context.Result = new BadRequestObjectResult(new { Errors = errors });
                return;
            }
        }

        await next();
    }
}
