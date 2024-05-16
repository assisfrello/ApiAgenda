using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.Utils;
using FluentValidation;
using FluentValidation.Results;

namespace ApiAgenda.Domain.ViewModels;

public class AgendaBuscarDadosRequisicaoViewModel
{
    public string? Documento { get; set; }

    public ValidationResult ValidarRequisicao()
    {
        return new AgendaBuscarDadosRequisicaoViewModelValidador().Validate(this);
    }
}

public class AgendaBuscarDadosRequisicaoViewModelValidador : AbstractValidator<AgendaBuscarDadosRequisicaoViewModel>
{
    public AgendaBuscarDadosRequisicaoViewModelValidador()
    {
        RuleFor(o => o.Documento)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString())
            .Must(StringUtils.ValidarDocumento!)
            .WithMessage(Mensagens.CampoInvalido().Mensagem?.FormatEx("{PropertyName}"));
    }
}