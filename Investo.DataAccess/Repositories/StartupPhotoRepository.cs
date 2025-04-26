namespace Investo.DataAccess.Repositories;

using Investo.DataAccess.Interfaces;
using Investo.DataAccess.Entities;
using Investo.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PawHavenApp.DataAccess.Repositories;

public class StartupPhotoRepository : AbstractRepository, IStartupPhotoRepository
{
    private readonly DbSet<StartupPhoto> dbSet;

    public StartupPhotoRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<StartupPhoto>();
    }

    public async Task<int> CreateAsync(StartupPhoto entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<StartupPhoto>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IEnumerable<StartupPhoto>> GetAllAsync(int page, int pageSize)
    {
        return await dbSet
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<StartupPhoto>> GetAllAsync(Expression<Func<StartupPhoto, bool>> predicate)
    {
        return await dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<StartupPhoto?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(StartupPhoto entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(StartupPhoto entity)
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