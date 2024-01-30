using System.Net;
using System.Net.Http.Json;
using ApiAgenda.Data.Tests.Common;
using FluentAssertions;
using Xunit;

namespace ApiAgenda.Data.Tests;

public class AgendaControllerTests : IClassFixture<WebAppFactory<Program>>
{
    private readonly WebAppFactory<Program> _factory;
    private readonly AgendaControllerTestsFixture _fixture;
    

    public AgendaControllerTests(WebAppFactory<Program> factory)
    {
        _factory = factory;
        _fixture = new AgendaControllerTestsFixture();
    }
    
    [Fact(DisplayName = "Retorna status 'ok' quando criado o item")]
    public async Task Post_Item_RetornaStatusOk()
    {
        //Arrange
        var request = _fixture.GerarRequisicaoValida();
        var app = _factory.CreateClient();
        
        //Act
        var response = await app.PostAsJsonAsync("/api/Agenda", request);
        
        //Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}