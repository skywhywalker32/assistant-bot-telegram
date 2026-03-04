using AssistantBot.Application.Abstractions.Persistence;
using AssistantBot.Domain.Entities;
using AssistantBot.Infrastructure.Persistence.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Contexts;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}