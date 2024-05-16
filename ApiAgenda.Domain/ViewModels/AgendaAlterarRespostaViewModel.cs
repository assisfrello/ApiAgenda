using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.ViewModels.Base;

namespace ApiAgenda.Domain.ViewModels;

public class AgendaAlterarRespostaViewModel : ResponseBaseViewModel
{
    
    public static AgendaAlterarRespostaViewModel RetornarSucesso()
    {
        return new AgendaAlterarRespostaViewModel { Sucesso = false, Mensagem = Mensagens.Sucesso().Mensagem};
    }
    
    public static AgendaAlterarRespostaViewModel RetornarErro(string? mensagem)
    {
        return new AgendaAlterarRespostaViewModel { Sucesso = false, Mensagem = mensagem};
    }

    public static AgendaAlterarRespostaViewModel RetornarConsultaSemResultados()
    {
        return new AgendaAlterarRespostaViewModel { Sucesso = false, Mensagem = Mensagens.ConsultaSemResultados().Mensagem};
    }
}