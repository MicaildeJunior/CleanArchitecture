using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GetUser;

public class GetUserByIdHandler : IRequestHandler<GetUserRequest, Result<UserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<UserResponse>> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user is null)
        {
            return Result<UserResponse>.Failure(new List<string> { "Usuário não encontrado na base de dados." });
        }

        var userResponse = _mapper.Map<UserResponse>(user);
        return Result<UserResponse>.Success(userResponse);
    }
}
