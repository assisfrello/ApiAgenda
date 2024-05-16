using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.ViewModels.Base;

namespace ApiAgenda.Domain.ViewModels;

public partial class AgendaAdicionarRespostaViewModel : ResponseBaseViewModel
{
    
}

public partial class AgendaAdicionarRespostaViewModel
{
    public static AgendaAdicionarRespostaViewModel RetornarErro(string? mensagem)
    {
        return new AgendaAdicionarRespostaViewModel { Sucesso = false, Mensagem = mensagem };
    }
    
    public static AgendaAdicionarRespostaViewModel RetornarSucesso()
    {
        return new AgendaAdicionarRespostaViewModel { Sucesso = true, Mensagem = Mensagens.Sucesso().Mensagem };
    }
}