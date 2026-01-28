using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.GelAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.API.Extensions;
using CleanArchitecture.Application.Shared;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetById(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUserRequest(), cancellationToken);

        return result.ToActionResult();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
                
        return result.ToActionResult();
    }


    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
    {     
        var result = await _mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }
}
