using ApiAgenda.Domain.Messages;
using ApiAgenda.Domain.Utils;
using FluentValidation;
using FluentValidation.Results;

namespace ApiAgenda.Domain.ViewModels;

public class AgendaAdicionarRequisicaoViewModel
{
    public string? Documento { get; set; } 
    public string? Nome { get; set; } 
    public AgendaContatoAdicionarRequisicaoViewModel? Contato { get; set; }
    public AgendaEnderecoAdicionarRequisicaoViewModel? Endereco { get; set; }

    public ValidationResult ValidarRequisicao()
    {
        return new AgendaAdicionarRequisicaoViewModelValidador().Validate(this);
    }
}

public class AgendaContatoAdicionarRequisicaoViewModel
{
    public string? Celular { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}

public class AgendaEnderecoAdicionarRequisicaoViewModel
{
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; } 
    public string? Cidade { get; set; } 
    public string? Uf { get; set; } 
}

public class AgendaAdicionarRequisicaoViewModelValidador : AbstractValidator<AgendaAdicionarRequisicaoViewModel>
{
    public AgendaAdicionarRequisicaoViewModelValidador()
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
        
        When(r => r.Contato != null, () =>
        {
            RuleFor(r => r.Contato).SetValidator(new AgendaContatoAdicionarRequisicaoViewModelValidador()!);
        });
        
        When(r => r.Endereco != null, () =>
        {
            RuleFor(r => r.Endereco).SetValidator(new AgendaEnderecoAdicionarRequisicaoViewModelValidador()!);
        });
    }
}

public class AgendaContatoAdicionarRequisicaoViewModelValidador : AbstractValidator<AgendaContatoAdicionarRequisicaoViewModel>
{
    public AgendaContatoAdicionarRequisicaoViewModelValidador()
    {
        RuleFor(o => o.Celular)
            .NotEmpty().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString());
        
        When(r => r.Email != null, () =>
        {
            RuleFor(o => o.Email)
                .Cascade(CascadeMode.Stop)
                .Must(o => o.ValidarEmail())
                .WithMessage(Mensagens.CampoInvalido().Mensagem?.FormatEx("{PropertyName}"));
        });
    }
}

public class AgendaEnderecoAdicionarRequisicaoViewModelValidador : AbstractValidator<AgendaEnderecoAdicionarRequisicaoViewModel>
{
    public AgendaEnderecoAdicionarRequisicaoViewModelValidador()
    {
        RuleFor(o => o.Logradouro)
            .NotNull().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString());
        
        RuleFor(o => o.Bairro)
            .NotNull().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString());
        
        RuleFor(o => o.Cidade)
            .NotNull().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString());
        
        RuleFor(o => o.Uf)
            .NotNull().WithMessage(Mensagens.Obrigatorio().Mensagem?.FormatEx("{PropertyName}"))
            .WithErrorCode(Mensagens.Obrigatorio().CodigoMensagem.ToString())
            .Must(StringUtils.ValidarUf!)
            .WithMessage(Mensagens.CampoInvalido().Mensagem?.FormatEx("{PropertyName}"));
    }
}