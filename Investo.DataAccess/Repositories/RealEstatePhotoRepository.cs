namespace Investo.DataAccess.Repositories;

using Investo.DataAccess.Interfaces;
using Investo.DataAccess.Entities;
using Investo.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PawHavenApp.DataAccess.Repositories;

public class RealEstatePhotoRepository : AbstractRepository, IRealEstatePhotoRepository
{
    private readonly DbSet<RealEstatePhoto> dbSet;

    public RealEstatePhotoRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<RealEstatePhoto>();
    }

    public async Task<int> CreateAsync(RealEstatePhoto entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<RealEstatePhoto>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IEnumerable<RealEstatePhoto>> GetAllAsync(int page, int pageSize)
    {
        return await dbSet
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<RealEstatePhoto>> GetAllAsync(Expression<Func<RealEstatePhoto, bool>> predicate)
    {
        return await dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<RealEstatePhoto?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(RealEstatePhoto entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RealEstatePhoto entity)
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