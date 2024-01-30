using ApiAgenda.Domain.Entities;
using Bogus;
using Bogus.Extensions.Brazil;

namespace ApiAgenda.Data.Tests;

public class AgendaRepositoryTestsFixture
{
    private const string Locale = "pt_BR";
    
    public Agenda GerarRequisicaoValida()
    {
        return new Faker<Agenda>(Locale).CustomInstantiator(_ =>
            new Agenda
            {
                Documento = _.Person.Cpf(),
                Nome = _.Person.FullName,
                Contato = new AgendaContato
                {
                    Celular = _.Person.Phone,
                    Email = _.Person.Email
                },
                Endereco = new AgendaEndereco
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