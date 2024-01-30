using ApiAgenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAgenda.Data.EntityConfigurations;

public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
{
    public void Configure(EntityTypeBuilder<Agenda> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
    }
}