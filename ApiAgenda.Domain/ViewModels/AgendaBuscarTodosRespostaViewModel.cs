using ApiAgenda.Domain.ViewModels.Base;

namespace ApiAgenda.Domain.ViewModels;

public class AgendaBuscarTodosRespostaViewModel : ResponseBaseViewModel
{
    public List<AgendaBuscarTodosDadosRespostaViewModel>? Objeto { get; set; }

    public AgendaBuscarTodosRespostaViewModel RetornarSucesso(List<AgendaBuscarTodosDadosRespostaViewModel> objeto)
    {
        return new AgendaBuscarTodosRespostaViewModel
        {
            Sucesso = true,
            Mensagem = Messages.Mensagens.Sucesso().Mensagem,
            Objeto = objeto
        };
    }
    
    public AgendaBuscarTodosRespostaViewModel RetornarConsultaSemResultados()
    {
        return new AgendaBuscarTodosRespostaViewModel
        {
            Sucesso = true,
            Mensagem = Messages.Mensagens.ConsultaSemResultados().Mensagem
        };
    }
}

public class AgendaBuscarTodosDadosRespostaViewModel
{
    public string Documento { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public virtual AgendaBuscarTodosDadosContatoRespostaViewModel? Contato { get; set; }
    public virtual AgendaBuscarTodosDadosEnderecoRespostaViewModel? Endereco { get; set; }
}

public class AgendaBuscarTodosDadosContatoRespostaViewModel
{
    public string Celular { get; set; } = null!;
    public string? Telefone { get; set; } 
    public string? Email { get; set; } 
}

public class AgendaBuscarTodosDadosEnderecoRespostaViewModel
{
    public string Logradouro { get; set; } = null!;
    public string Numero { get; set; } = null!;
    public string? Complemento { get; set; }
    public string Bairro { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Uf { get; set; } = null!;
}