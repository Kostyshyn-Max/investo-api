namespace Investo.DataAccess.Repositories;

using Investo.DataAccess.Interfaces;
using Investo.DataAccess.Entities;
using Investo.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PawHavenApp.DataAccess.Repositories;

public class StartupRepository : AbstractRepository, IStartupRepository
{
    private readonly DbSet<Startup> dbSet;

    public StartupRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<Startup>();
    }

    public async Task<int> CreateAsync(Startup entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Startup>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IEnumerable<Startup>> GetAllAsync(int page, int pageSize)
    {
        return await dbSet
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Startup>> GetAllAsync(Expression<Func<Startup, bool>> predicate)
    {
        return await dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<Startup?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(Startup entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Startup entity)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await dbSet.FindAsync(id);
        if (entity != null)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}