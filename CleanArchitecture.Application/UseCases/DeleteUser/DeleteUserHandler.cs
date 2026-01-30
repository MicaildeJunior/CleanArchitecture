using AutoMapper;
using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Result<DeleteUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<DeleteUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user is null)
        {
            return Result<DeleteUserResponse>.Failure([$"Usuário não encontrado com esse Id: {request.Id}."]);
        }
        
        user.Ativo = false;
        _userRepository.Delete(user);
        await _unitOfWork.Commit(cancellationToken);

        var response = _mapper.Map<DeleteUserResponse>(user);

        return Result<DeleteUserResponse>.Success(response);
    }
}
