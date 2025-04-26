namespace Investo.DataAccess.Repositories;

using Investo.DataAccess.Interfaces;
using Investo.DataAccess.Entities;
using Investo.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using PawHavenApp.DataAccess.Repositories;

public class PublisherTestimonialRepository : AbstractRepository, IPublisherTestimonialRepository
{
    private readonly DbSet<PublisherTestimonial> dbSet;

    public PublisherTestimonialRepository(ApplicationDbContext context)
        : base(context)
    {
        this.dbSet = context.Set<PublisherTestimonial>();
    }

    public async Task<int> CreateAsync(PublisherTestimonial entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<PublisherTestimonial>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<IEnumerable<PublisherTestimonial>> GetAllAsync(int page, int pageSize)
    {
        return await dbSet
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<PublisherTestimonial>> GetAllAsync(Expression<Func<PublisherTestimonial, bool>> predicate)
    {
        return await dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<PublisherTestimonial?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(PublisherTestimonial entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PublisherTestimonial entity)
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