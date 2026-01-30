using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    //private readonly IUnitOfWork _unitOfWork;

    //public UserRepository(IUnitOfWork unitOfWork)
    //{
    //    _unitOfWork = unitOfWork;
    //}

    //public async Task<User> DesativeUser(Guid Id, CancellationToken cancellationToken)
    //{
    //    var user = Context.Users.FirstOrDefault(u => u.Id == Id);

    //    if (user is null)        
    //        throw new KeyNotFoundException($"Usuário com ID '{Id}' não encontrado.");

    //    if (user.Ativo == false)
    //    {
    //        user.DateDeleted = null;
    //        await _unitOfWork.Commit(cancellationToken);
    //    }

    //    return user;        
    //}

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken)
            ?? throw new KeyNotFoundException($"Usuário com email '{email}' não encontrado.");
    }
}
