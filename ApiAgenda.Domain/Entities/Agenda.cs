using ApiAgenda.Domain.ViewModels;

namespace ApiAgenda.Domain.Entities;

public class Agenda : Entity
{
    public string Documento { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public virtual AgendaContato? Contato { get; set; }
    public virtual AgendaEndereco? Endereco { get; set; }

    public void MapearAlteracoes(AgendaAlterarRequisicaoViewModel model)
    {
        Nome = model.Nome != null && model.Nome != Nome ? model.Nome : Nome;
        
        if (model.Contato != null)
        {
            Contato ??= new AgendaContato();
            
            Contato.Celular = model.Contato.Celular != null && model.Contato.Celular != Contato.Celular ? model.Contato.Celular : Contato.Celular;
            Contato.Email = model.Contato.Email != null && model.Contato.Email != Contato.Email ? model.Contato.Email : Contato.Email;
            Contato.Telefone = model.Contato.Telefone != null && model.Contato.Telefone != Contato.Telefone ? model.Contato.Telefone : Contato.Telefone;
        }

        if (model.Endereco != null)
        {
            Endereco ??= new AgendaEndereco();
            
            Endereco.Logradouro = model.Endereco.Logradouro != null && model.Endereco.Logradouro != Endereco.Logradouro ? model.Endereco.Logradouro : Endereco.Logradouro;
            Endereco.Numero = model.Endereco.Numero != null && model.Endereco.Numero != Endereco.Numero ? model.Endereco.Numero : Endereco.Numero;
            Endereco.Complemento = model.Endereco.Complemento != null && model.Endereco.Complemento != Endereco.Complemento ? model.Endereco.Complemento : Endereco.Complemento;
            Endereco.Bairro = model.Endereco.Bairro != null && model.Endereco.Bairro != Endereco.Bairro ? model.Endereco.Bairro : Endereco.Bairro;
            Endereco.Cidade = model.Endereco.Cidade != null && model.Endereco.Cidade != Endereco.Cidade ? model.Endereco.Cidade : Endereco.Cidade;
            Endereco.Uf = model.Endereco.Uf != null && model.Endereco.Uf != Endereco.Uf ? model.Endereco.Uf : Endereco.Uf;
        }
    }
}

