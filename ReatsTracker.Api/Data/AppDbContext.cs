using Microsoft.EntityFrameworkCore;
using ReatsTracker.Api.Models;

namespace ReatsTracker.Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<Company> Companies { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // cascade deletion 
        modelBuilder.Entity<Vacancy>()
            .HasOne(v => v.Company)
            .WithMany(c => c.Vacancies)
            .HasForeignKey(v => v.CompanyId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}