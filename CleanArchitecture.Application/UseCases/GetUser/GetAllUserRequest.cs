using CleanArchitecture.Application.Shared;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GelAllUser;

public sealed record GetAllUserRequest : IRequest<Result<List<GetAllUserResponse>>>;

