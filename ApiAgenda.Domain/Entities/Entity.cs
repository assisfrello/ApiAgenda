namespace ApiAgenda.Domain.Entities;

public class Entity
{
    public int Id { get; set; }

    public DateTime DataCadastro { get; set; }

    public DateTime? DataAtualizacao { get; set; }
    
    public virtual bool EhValido() => throw new NotImplementedException();

    public override bool Equals(object obj)
    {
        Entity entity = obj as Entity;
        if ((object) this == (object) entity)
            return true;
        return (object) entity != null && this.Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity? a, Entity b)
    {
        if ((object) a == null && (object) b == null)
            return true;
        return (object) a != null && (object) b != null && a.Equals((object) b);
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override int GetHashCode() => this.GetType().GetHashCode() * 907 + this.Id.GetHashCode();

    public override string ToString() => string.Format("{0} [Id={1}]", (object) this.GetType().Name, (object) this.Id);
}