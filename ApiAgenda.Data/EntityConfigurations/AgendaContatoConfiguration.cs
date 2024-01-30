using ApiAgenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAgenda.Data.EntityConfigurations;

public class AgendaContatoConfiguration : IEntityTypeConfiguration<AgendaContato>
{
    public void Configure(EntityTypeBuilder<AgendaContato> builder)
    {
        builder.HasKey(p => p.IdAgenda);
        
        builder.Property(p => p.Celular).HasColumnType("varchar(20)").IsRequired();
        builder.Property(p => p.Telefone).HasColumnType("varchar(20)").IsRequired(false);
        builder.Property(p => p.Email).HasColumnType("varchar(100)").IsRequired(false);
        
        builder.HasOne(p => p.Agenda)
            .WithOne(p => p.Contato)
            .HasForeignKey<AgendaContato>(p => p.IdAgenda);
    }
}