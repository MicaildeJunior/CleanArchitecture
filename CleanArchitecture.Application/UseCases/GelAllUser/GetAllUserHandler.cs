using AutoMapper;
using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.GelAllUser;

public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, Result<List<GetAllUserResponse>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllUserResponse>>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(cancellationToken);

        var response = _mapper.Map<List<GetAllUserResponse>>(users);

        return Result<List<GetAllUserResponse>>.Success(response);
    }
}
