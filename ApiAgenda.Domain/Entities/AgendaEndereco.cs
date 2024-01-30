namespace ApiAgenda.Domain.Entities;

public class AgendaEndereco
{
    public int IdAgenda { get; set; }
    public string Logradouro { get; set; } = null!;
    public string Numero { get; set; } = null!;
    public string Complemento { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Uf { get; set; } = null!;
    
    public virtual Agenda Agenda { get; set; }
}