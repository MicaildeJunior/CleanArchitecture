using CleanArchitecture.API.Extensions;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.DeleteUser;
using CleanArchitecture.Application.UseCases.GelAllUser;
using CleanArchitecture.Application.UseCases.GetUser;
using CleanArchitecture.Application.UseCases.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserRequest(id), cancellationToken);

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

    [HttpPut]
    public async Task<ActionResult<UpdateUserResponse>> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);

        return result.ToActionResult();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeleteUserResponse>> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
       var result = await _mediator.Send(new DeleteUserRequest(id), cancellationToken);

        return result.ToActionResult();
    }
}
