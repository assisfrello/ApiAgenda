using ApiAgenda.Domain.Interfaces.Service;
using ApiAgenda.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgendaController : ControllerBase
{
    private readonly IAgendaService _service;

    public AgendaController(IAgendaService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AgendaAdicionarRespostaViewModel), 201)]
    public async Task<AgendaAdicionarRespostaViewModel> Post([FromBody] AgendaAdicionarRequisicaoViewModel model) =>
        await _service.Adicionar(model);

    [HttpGet]
    public Task<AgendaBuscarRespostaViewModel> Get([FromQuery] AgendaBuscarDadosRequisicaoViewModel model) =>
        _service.Buscar(model);

    [HttpGet]
    [Route("GetAll")]
    public Task<AgendaBuscarTodosRespostaViewModel> GetAll() => _service.BuscarTodos();

    [HttpPut]
    public async Task<AgendaAlterarRespostaViewModel> Update([FromBody] AgendaAlterarRequisicaoViewModel model) =>
        await _service.Alterar(model);

    [HttpDelete]
    public async Task<AgendaExcluirRespostaViewModel> Delete([FromQuery] AgendaExcluirRequisicaoViewModel model) =>
        await _service.Excluir(model);
}