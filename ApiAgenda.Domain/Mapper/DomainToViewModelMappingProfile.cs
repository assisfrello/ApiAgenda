using ApiAgenda.Domain.Entities;
using ApiAgenda.Domain.ViewModels;
using AutoMapper;

namespace ApiAgenda.Domain.Mapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        ConfigureAgendaMap();
    }

    private void ConfigureAgendaMap()
    {
        //Buscar único registro
        CreateMap<AgendaEndereco, AgendaBuscarDadosEnderecoRespostaViewModel>();
        CreateMap<AgendaContato, AgendaBuscarDadosContatoRespostaViewModel>();
        CreateMap<Agenda, AgendaBuscarDadosRespostaViewModel>();
        
        //Buscar todos
        CreateMap<AgendaEndereco, AgendaBuscarTodosDadosEnderecoRespostaViewModel>();
        CreateMap<AgendaContato, AgendaBuscarTodosDadosContatoRespostaViewModel>();
        CreateMap<Agenda, AgendaBuscarTodosDadosRespostaViewModel>();
    }
}