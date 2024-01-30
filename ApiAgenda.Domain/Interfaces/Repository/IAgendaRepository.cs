using ApiAgenda.Domain.Entities;

namespace ApiAgenda.Domain.Interfaces.Repository;

public interface IAgendaRepository
{
    Task<Agenda> Adicionar(Agenda agenda);
    Agenda? Buscar(string documento);
    List<Agenda> BuscarTodos();
    Task Alterar(Agenda registro);
    Task Excluir(Agenda registro);
}