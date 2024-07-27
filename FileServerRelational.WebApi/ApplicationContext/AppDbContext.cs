using FileServerRelational.WebApi.Models.Misc;
using FileServerRelational.WebApi.Models.Sbj;
using Microsoft.EntityFrameworkCore;

namespace FileServerRelational.WebApi.ApplicationContext
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Configures the model that was discovered by convention from the entity types
        /// exposed in <see cref="DbSet{TEntity}"/> properties on your derived context.
        /// The resulting model may be cached and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().ToContainer("Subjects");
            modelBuilder.Entity<Question>().ToContainer("Questions");
            modelBuilder.Entity<Answer>().ToContainer("Answers");
            modelBuilder.Entity<Salary>().ToContainer("Salaries");

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Subject"/>.
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Question"/>.
        /// </summary>
        public DbSet<Question> Questions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Answer"/>.
        /// </summary>
        public DbSet<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="Salary"/>.
        /// </summary>
        public DbSet<Salary> Salaries { get; set; }
    }
}
