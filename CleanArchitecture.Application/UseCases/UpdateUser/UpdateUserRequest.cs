using CleanArchitecture.Application.Shared;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public sealed record UpdateUserRequest(Guid Id, string Email, string Name, bool Ativo) : IRequest<Result<UpdateUserResponse>>;