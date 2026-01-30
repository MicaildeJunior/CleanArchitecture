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

        if(entity.Ativo == true)        
            entity.DateDeleted = null;
        
        if (entity.Ativo == false)        
            entity.DateDeleted = DateTimeOffset.UtcNow;        

        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateDeleted = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }

    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        var entity = await Context.Set<T>()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await Context.Set<T>()
            .Where(e => e.Ativo == true)
            .ToListAsync(cancellationToken);
    }

}
