using ApiAgenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Data.Context;

public class AgendaContext : DbContext
{
    public AgendaContext(DbContextOptions<AgendaContext> options)
        : base(options)
    { }
    
    public DbSet<Agenda> Agenda { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(
            "Server=localhost,5432;Database=Agenda;User ID=postgres;Password=postgres;");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgendaContext).Assembly);
    }
    
    public async Task<int> Commit()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    if (entry.Entity.GetType().GetProperty(nameof(Entity.DataCadastro)) != null)
                        entry.Property(nameof(Entity.DataCadastro)).CurrentValue = DateTime.Now;
                    break;

                case EntityState.Modified:
                    if (entry.Entity.GetType().GetProperty(nameof(Entity.DataCadastro)) != null)
                        entry.Property(nameof(Entity.DataCadastro)).IsModified = false;

                    if (entry.Entity.GetType().GetProperty(nameof(Entity.DataAtualizacao)) != null)
                        if (entry.Member(nameof(Entity.DataAtualizacao)) != null)
                            entry.Property(nameof(Entity.DataAtualizacao)).CurrentValue = DateTime.Now;
                    break;
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return await base.SaveChangesAsync();
    }
}