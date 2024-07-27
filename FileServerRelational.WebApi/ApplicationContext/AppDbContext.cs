﻿using FileServerRelational.WebApi.Models.Misc;
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
        modelBuilder.Entity<Subject>().ToContainer("Subjects");
        modelBuilder.Entity<Question>().ToContainer("Questions");
        modelBuilder.Entity<Answer>().ToContainer("Answers");
        modelBuilder.Entity<Salary>().ToContainer("Salaries");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Salary> Salaries { get; set; }
}
