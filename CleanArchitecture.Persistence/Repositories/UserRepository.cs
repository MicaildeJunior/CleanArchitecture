using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await Context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken)
            ?? throw new KeyNotFoundException($"User with email '{email}' not found.");
    }
}
