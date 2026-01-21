using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context = context;

    public void Create(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        Context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.DateUpdated = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTimeOffset.UtcNow;
       Context.Remove(entity);
    }

    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        var entity = await Context.Set<T>()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity is null ? throw new KeyNotFoundException($"Entidade com o ID {id} não foi encontrada.") : entity;
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>()
            .ToListAsync(cancellationToken);
    }

}
