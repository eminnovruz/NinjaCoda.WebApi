using FileServerRelational.WebApi.Models.Misc;
using FileServerRelational.WebApi.Models.Sbj;
using Microsoft.EntityFrameworkCore;

namespace FileServerRelational.WebApi.ApplicationContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subject>().ToContainer("MainSubjects");
        modelBuilder.Entity<Question>().ToContainer("Questions");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Subject> MainSubjects { get; set; }
    public DbSet<Question> Questions { get; set; }
}
