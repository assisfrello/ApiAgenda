using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.ViewModels.Base;

namespace ApiAgenda.Domain.ViewModels;

public partial class AgendaBuscarRespostaViewModel : ResponseBaseViewModel
{
    public AgendaBuscarDadosRespostaViewModel? Objeto { get; set; }
}

public partial class AgendaBuscarRespostaViewModel
{
    public AgendaBuscarRespostaViewModel RetornarSucesso(AgendaBuscarDadosRespostaViewModel objeto)
    {
        return new AgendaBuscarRespostaViewModel
        {
            Sucesso = true,
            Mensagem = Mensagens.Sucesso().Mensagem,
            Objeto = objeto
        };
    }
    
    public static AgendaBuscarRespostaViewModel RetornarErro(string? mensagem)
    {
        return new AgendaBuscarRespostaViewModel { Sucesso = false, Mensagem = mensagem };
    }
    
    public static AgendaBuscarRespostaViewModel RetornarConsultaSemResultados()
    {
        return new AgendaBuscarRespostaViewModel { Sucesso = false, Mensagem = Mensagens.ConsultaSemResultados().Mensagem };
    }
}

public class AgendaBuscarDadosRespostaViewModel
{
    public string Documento { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public virtual AgendaBuscarDadosContatoRespostaViewModel? Contato { get; set; }
    public virtual AgendaBuscarDadosEnderecoRespostaViewModel? Endereco { get; set; }
}

public class AgendaBuscarDadosContatoRespostaViewModel
{
    public string Celular { get; set; } = null!;
    public string? Telefone { get; set; } 
    public string? Email { get; set; } 
}

public class AgendaBuscarDadosEnderecoRespostaViewModel
{
    public string Logradouro { get; set; } = null!;
    public string Numero { get; set; } = null!;
    public string? Complemento { get; set; }
    public string Bairro { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Uf { get; set; } = null!;
}