using Microsoft.EntityFrameworkCore;
using FilmApp.WebServiceCore.Entities;


namespace FilmApp.WebServiceCore.Database;

public class ApplicationDbContext : DbContext
{

    public DbSet<Users> User { get; set; }
    public DbSet<Films> Film { get; set; }
    public DbSet<Comments> Comment { get; set; }
    public DbSet<Ratings> Rating { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

}