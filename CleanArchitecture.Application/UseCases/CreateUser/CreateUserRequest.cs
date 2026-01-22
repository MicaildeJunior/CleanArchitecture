using MediatR;

namespace CleanArchitecture.Application.UseCases.CreateUser;

public sealed record CreateUserRequest(string Name, string Email) : IRequest<CreateUserResponse>;

