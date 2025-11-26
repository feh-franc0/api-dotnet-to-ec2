namespace ApiSeguidores.Models;

public class Seguidor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public TimeSpan Hora { get; set; }
}