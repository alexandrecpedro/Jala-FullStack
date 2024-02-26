namespace DDDWebAPI.Domain.Models;

public class Produto : Base
{
    public decimal Valor { get; set; }
    public bool Disponivel { get; set; }
    public Guid ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
}