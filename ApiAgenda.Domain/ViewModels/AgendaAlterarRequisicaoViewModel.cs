using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.Utils;
using FluentValidation;
using FluentValidation.Results;

namespace ApiAgenda.Domain.ViewModels;

public partial class AgendaAlterarRequisicaoViewModel
{
    public string? Documento { get; set; } 
    public string? Nome { get; set; } 
    public AgendaContatoAlterarRequisicaoViewModel? Contato { get; set; }
    public AgendaEnderecoAlterarRequisicaoViewModel? Endereco { get; set; }

}

public partial class AgendaAlterarRequisicaoViewModel 
{
    public ValidationResult ValidarRequisicao()
    {
        return new AgendaAlterarRequisicaoViewModelValidador().Validate(this);
    }
}

public class AgendaContatoAlterarRequisicaoViewModel
{
    public string? Celular { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}

public class AgendaEnderecoAlterarRequisicaoViewModel
{
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; } 
    public string? Cidade { get; set; } 
    public string? Uf { get; set; } 
}

public class AgendaAlterarRequisicaoViewModelValidador : AbstractValidator<AgendaAlterarRequisicaoViewModel>
{
    public AgendaAlterarRequisicaoViewModelValidador()
    {
        RuleFor(o => o.Documento)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString())
            .Must(StringUtils.ValidarDocumento!)
            .WithMessage(Mensagens.CampoInvalido().Mensagem?.FormatEx("{PropertyName}"));
        
        RuleFor(o => o.Nome)
            .NotEmpty().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString());
                
        RuleFor(o => o.Contato)
            .NotNull().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString());
        
        
    }
}