using ApiAgenda.Data.Context;
using ApiAgenda.Data.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ApiAgenda.Data.Tests;

public class AgendaRepositoryTests : IDisposable
{
    private readonly AgendaContext _context;
    private readonly AgendaRepository _repository;
    private readonly AgendaRepositoryTestsFixture _fixture;

    public AgendaRepositoryTests()
    {
        _fixture = new AgendaRepositoryTestsFixture();
        var options = new DbContextOptionsBuilder<AgendaContext>()
            .UseNpgsql("Server=localhost,5432;Database=Agenda_Tests;User ID=postgres;Password=postgres;")
            .Options;
        
        _context = new AgendaContext(options);
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();
        
        _repository = new AgendaRepository(_context);
    }
    
    [Fact]
    public async Task Agenda_AdicionarRegistro_DeveAdicionarRegistro()
    {
        var requisicao = _fixture.GerarRequisicaoValida();

        var registro =  _context.Agenda.Add(requisicao);
        
        await _context.SaveChangesAsync();
        
        var agenda = _repository.Buscar(requisicao.Documento);
        
        await _repository.Excluir(registro.Entity);
        
        await _context.SaveChangesAsync();

        agenda.Should().NotBeNull();
        registro.Should().Be(registro);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}