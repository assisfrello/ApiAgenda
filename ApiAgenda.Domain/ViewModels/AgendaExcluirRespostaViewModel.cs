using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.ViewModels.Base;

namespace ApiAgenda.Domain.ViewModels;

public class AgendaExcluirRespostaViewModel : ResponseBaseViewModel
{
    
    public static AgendaExcluirRespostaViewModel RetornarSucesso()
    {
        return new AgendaExcluirRespostaViewModel { Sucesso = true, Mensagem = Mensagens.Sucesso().Mensagem};
    }
    
    public static AgendaExcluirRespostaViewModel RetornarErro(string? mensagem)
    {
        return new AgendaExcluirRespostaViewModel { Sucesso = false, Mensagem = mensagem};
    }    
    
    public static AgendaExcluirRespostaViewModel RetornarConsultaSemResultados()
    {
        return new AgendaExcluirRespostaViewModel { Sucesso = false, Mensagem = Mensagens.ConsultaSemResultados().Mensagem};
    }
}