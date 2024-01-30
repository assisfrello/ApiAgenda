namespace ApiAgenda.Domain.Entities;

public class AgendaContato
{
    public int IdAgenda { get; set; }
    public string Celular { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    public virtual Agenda Agenda { get; set; }
}