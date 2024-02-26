namespace DDDWebAPI.Domain.Models;

public class Cliente : Base
{
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
}