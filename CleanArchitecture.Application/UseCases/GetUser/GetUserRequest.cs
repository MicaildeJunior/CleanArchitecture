using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Shared;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetUser;

public sealed record GetUserRequest(Guid Id) : IRequest<Result<UserResponse>>;
