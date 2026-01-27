using CleanArchitecture.Application.Shared;
using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed record CreateUserRequest(string Name, string Email) : IRequest<Result<CreateUserResponse>>;

