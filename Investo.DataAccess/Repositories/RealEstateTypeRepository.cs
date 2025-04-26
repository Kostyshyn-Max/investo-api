namespace Investo.DataAccess.Repositories;

using Investo.DataAccess.Interfaces;
using Investo.DataAccess.Entities;
using Investo.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PawHavenApp.DataAccess.Repositories;

public class RealEstateTypeRepository : AbstractRepository, IRealEstateTypeRepository
{
    private readonly DbSet<RealEstateType> dbSet;

    public RealEstateTypeRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<RealEstateType>();
    }

    public async Task<int> CreateAsync(RealEstateType entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<RealEstateType>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IEnumerable<RealEstateType>> GetAllAsync(int page, int pageSize)
    {
        return await dbSet
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<RealEstateType>> GetAllAsync(Expression<Func<RealEstateType, bool>> predicate)
    {
        return await dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<RealEstateType?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(RealEstateType entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RealEstateType entity)
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