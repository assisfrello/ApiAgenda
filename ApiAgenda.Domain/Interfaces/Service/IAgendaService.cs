using ApiAgenda.Domain.ViewModels;

namespace ApiAgenda.Domain.Interfaces.Service;

public interface IAgendaService
{
    Task<AgendaAdicionarRespostaViewModel> Adicionar(AgendaAdicionarRequisicaoViewModel model);
    Task<AgendaBuscarTodosRespostaViewModel> BuscarTodos();
    Task<AgendaBuscarRespostaViewModel> Buscar(AgendaBuscarDadosRequisicaoViewModel model);
    Task<AgendaExcluirRespostaViewModel> Excluir(AgendaExcluirRequisicaoViewModel model);
    Task<AgendaAlterarRespostaViewModel> Alterar(AgendaAlterarRequisicaoViewModel model);
}