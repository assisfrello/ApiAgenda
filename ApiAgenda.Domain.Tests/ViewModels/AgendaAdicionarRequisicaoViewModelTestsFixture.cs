using ApiAgenda.Domain.ViewModels;
using Bogus;
using Bogus.Extensions.Brazil;

namespace ApiAgenda.Domain.Tests.ViewModels;

public class AgendaAdicionarRequisicaoViewModelTestsFixture
{
    private const string Locale = "pt_BR";

    public AgendaAdicionarRequisicaoViewModel GerarRequisicaoValida()
    {
        return new Faker<AgendaAdicionarRequisicaoViewModel>(Locale).CustomInstantiator(_ =>
            new AgendaAdicionarRequisicaoViewModel
            {
                Documento = _.Person.Cpf(),
                Nome = _.Person.FullName,
                Contato = new AgendaContatoAdicionarRequisicaoViewModel
                {
                    Celular = _.Person.Phone,
                    Email = _.Person.Email
                },
                Endereco = new AgendaEnderecoAdicionarRequisicaoViewModel
                {
                    Logradouro = _.Address.StreetName(),
                    Numero = _.Address.BuildingNumber(),
                    Bairro = _.Address.State(),
                    Cidade = _.Address.City(),
                    Uf = "SC"
                }
            }).Generate();
    }
}