using FluentAssertions;
using Xunit;

namespace ApiAgenda.Domain.Tests.ViewModels;

public class AgendaAdicionarRequisicaoViewModelTests
{
    private const string CategoriaTrait = "Categoria Domain";
    private const string NomeCategoriaTrait = "Testes Agenda Adicionar Requisição ViewModel";

    private readonly AgendaAdicionarRequisicaoViewModelTestsFixture _fixture;

    public AgendaAdicionarRequisicaoViewModelTests()
    {
        _fixture = new AgendaAdicionarRequisicaoViewModelTestsFixture();
    }
    
    [Fact]
    [Trait(CategoriaTrait, NomeCategoriaTrait)]
    public void AgendaAdicionarRequisicaoViewModel_ValidarRequisicao_DeveSerValida()
    {
        // Arrange
        var requisicao = _fixture.GerarRequisicaoValida();
            
        // Action
        var resultado = requisicao.ValidarRequisicao();
            
        // Assert
        resultado.IsValid.Should().BeTrue();
        resultado.Errors.Count.Should().Be(0);
    }
}