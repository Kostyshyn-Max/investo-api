namespace PawHavenApp.DataAccess.Repositories;

using Investo.DataAccess.EF;

public abstract class AbstractRepository
{
    protected readonly ApplicationDbContext context;

    protected AbstractRepository(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        this.context = context;
    }
}