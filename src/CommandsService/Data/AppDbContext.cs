using MicroServicesDemo.CommandsService.Models;

using Microsoft.EntityFrameworkCore;

namespace MicroServicesDemo.CommandsService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Platform> Platforms { get; init; } = default!;

    public DbSet<Command> Commands { get; init; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
