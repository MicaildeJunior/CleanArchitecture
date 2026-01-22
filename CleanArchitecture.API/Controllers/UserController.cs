using CleanArchitecture.Application.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if(!validationResult.IsValid)        
            return BadRequest(validationResult.Errors);        

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
