using ApiAgenda.Domain.Entities;
using ApiAgenda.Domain.ViewModels;
using AutoMapper;

namespace ApiAgenda.Domain.Mapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        ConfigureAgendaMap();
    }

    private void ConfigureAgendaMap()
    {
        CreateMap<AgendaEnderecoAdicionarRequisicaoViewModel, AgendaEndereco>();
        CreateMap<AgendaContatoAdicionarRequisicaoViewModel, AgendaContato>();
        CreateMap<AgendaAdicionarRequisicaoViewModel, Agenda>();
    }
}