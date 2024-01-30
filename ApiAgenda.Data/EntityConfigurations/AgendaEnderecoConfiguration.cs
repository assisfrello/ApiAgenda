using ApiAgenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAgenda.Data.EntityConfigurations;

public class AgendaEnderecoConfiguration : IEntityTypeConfiguration<AgendaEndereco>
{
    public void Configure(EntityTypeBuilder<AgendaEndereco> builder)
    {
        builder.HasKey(p => p.IdAgenda);
        
        builder.Property(p => p.Logradouro).HasColumnType("varchar(100)").IsRequired();
        builder.Property(p => p.Numero).HasColumnType("varchar(8)").IsRequired(false);
        builder.Property(p => p.Complemento).HasColumnType("varchar(100)").IsRequired(false);
        builder.Property(p => p.Bairro).HasColumnType("varchar(100)").IsRequired();
        builder.Property(p => p.Cidade).HasColumnType("varchar(100)").IsRequired();
        builder.Property(p => p.Uf).HasColumnType("varchar(2)").IsRequired();
        
        builder.HasOne(p => p.Agenda)
            .WithOne(p => p.Endereco)
            .HasForeignKey<AgendaEndereco>(p => p.IdAgenda);
    }
}