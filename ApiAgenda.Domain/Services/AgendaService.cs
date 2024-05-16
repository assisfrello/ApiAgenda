using ApiAgenda.Domain.Entities;
using ApiAgenda.Domain.Interfaces.Repository;
using ApiAgenda.Domain.Interfaces.Service;
using ApiAgenda.Domain.ViewModels;
using AutoMapper;

namespace ApiAgenda.Domain.Services;

public class AgendaService : IAgendaService
{
    private readonly IAgendaRepository _repository;
    private readonly IMapper _mapper;

    public AgendaService(IAgendaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AgendaAdicionarRespostaViewModel> Adicionar(AgendaAdicionarRequisicaoViewModel model)
    {
        var retornoValidacao = model.ValidarRequisicao();
        if (!retornoValidacao.IsValid)
            return AgendaAdicionarRespostaViewModel.RetornarErro(retornoValidacao.Errors.FirstOrDefault()?.ErrorMessage);
        
        var agenda = _mapper.Map<Agenda>(model);

        await _repository.Adicionar(agenda);
        
        return AgendaAdicionarRespostaViewModel.RetornarSucesso();
    }
    
    public Task<AgendaBuscarRespostaViewModel> Buscar(AgendaBuscarDadosRequisicaoViewModel model)
    {
        var retornoValidacao = model.ValidarRequisicao();
        if (!retornoValidacao.IsValid)
            return Task.FromResult(
                AgendaBuscarRespostaViewModel.RetornarErro(retornoValidacao.Errors.FirstOrDefault()?.ErrorMessage));
        
        var retorno = _repository.Buscar(model.Documento!);
        
        return Task.FromResult(retorno == null
            ? AgendaBuscarRespostaViewModel.RetornarConsultaSemResultados() 
            : new AgendaBuscarRespostaViewModel().RetornarSucesso(_mapper.Map<AgendaBuscarDadosRespostaViewModel>(retorno)));
    }
    
    public Task<AgendaBuscarTodosRespostaViewModel> BuscarTodos()
    {
        var retorno = _repository.BuscarTodos();

        if (!retorno.Any())
            return Task.FromResult(new AgendaBuscarTodosRespostaViewModel().RetornarConsultaSemResultados());
         
        return Task.FromResult(new AgendaBuscarTodosRespostaViewModel().RetornarSucesso(
            _mapper.Map<List<AgendaBuscarTodosDadosRespostaViewModel>>(retorno)));
    }

    public async Task<AgendaAlterarRespostaViewModel> Alterar(AgendaAlterarRequisicaoViewModel model)
    {
        var retornoValidacao = model.ValidarRequisicao();
        if (!retornoValidacao.IsValid)
            return AgendaAlterarRespostaViewModel.RetornarErro(retornoValidacao.Errors.FirstOrDefault()?.ErrorMessage);
        
        var registro = _repository.Buscar(model.Documento!);
        
        if (registro == null)
            return AgendaAlterarRespostaViewModel.RetornarConsultaSemResultados();

        registro.MapearAlteracoes(model);
        
        await _repository.Alterar(registro);

        return AgendaAlterarRespostaViewModel.RetornarSucesso();
    }

    public async Task<AgendaExcluirRespostaViewModel> Excluir(AgendaExcluirRequisicaoViewModel model)
    {
        var retornoValidacao = model.ValidarRequisicao();
        if (!retornoValidacao.IsValid)
            return AgendaExcluirRespostaViewModel.RetornarErro(retornoValidacao.Errors.FirstOrDefault()?.ErrorMessage);
        
        var registro = _repository.Buscar(model.Documento!);
        
        if (registro == null)
            return AgendaExcluirRespostaViewModel.RetornarConsultaSemResultados();

        await _repository.Excluir(registro);

        return AgendaExcluirRespostaViewModel.RetornarSucesso();
    }
}