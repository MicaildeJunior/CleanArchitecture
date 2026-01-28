using AutoMapper;
using CleanArchitecture.Application.Shared;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result<UpdateUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user is null)
        {
            return Result<UpdateUserResponse>.Failure(new List<string>
            {
                "User.NotFound: O usuário informado não existe na base de dados."
            });
        }

        _mapper.Map(request, user);

        _userRepository.Update(user);
        await _unitOfWork.Commit(cancellationToken);

        var response = _mapper.Map<UpdateUserResponse>(user);
        return Result<UpdateUserResponse>.Success(response);
    }
}
