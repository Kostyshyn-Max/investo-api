namespace Investo.DataAccess.EF;

using Microsoft.EntityFrameworkCore;
using Investo.DataAccess.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Investment> Investments { get; set; }

    public DbSet<User> Users { get; set; }
    
    public DbSet<UserRole> UserRoles { get; set; }
    
    public DbSet<RealEstate> RealEstates { get; set; }
    
    public DbSet<RealEstatePhoto> RealEstatePhotos { get; set; }
    
    public DbSet<Startup> Startups { get; set; }
    
    public DbSet<StartupPhoto> StartupPhotos { get; set; }
    
    public DbSet<RealEstateType> RealEstateTypes { get; set; }
    
    public DbSet<PublisherTestimonial> PublisherTestimonials { get; set; }
}
