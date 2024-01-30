using ApiAgenda.Data.Context;
using ApiAgenda.Domain.Entities;
using ApiAgenda.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Data.Repository;

public class AgendaRepository : IAgendaRepository
{
    private readonly AgendaContext _context;

    public AgendaRepository(AgendaContext context)
    {
        _context = context;
    }

    public async Task<Agenda> Adicionar(Agenda agenda)
    {
        _context.Agenda.Add(agenda);
        await _context.Commit();

        return agenda;
    }

    public Agenda? Buscar(string documento)
    {
        return _context.Agenda
            .Include(o => o.Contato)
            .Include(o => o.Endereco)
            .FirstOrDefault(o => o.Documento == documento);
    }
    
    public List<Agenda> BuscarTodos()
    {
        return _context.Agenda
            .Include(o => o.Contato)
            .Include(o => o.Endereco)
            .ToList();
    }
    
    public async Task Alterar(Agenda registro)
    {
        _context.Agenda.Update(registro);
        
        await _context.Commit();
    }

    public async Task Excluir(Agenda registro)
    {
        _context.Agenda.Remove(registro);
        
        await _context.Commit();
    }
}