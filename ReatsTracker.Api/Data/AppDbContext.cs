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
}