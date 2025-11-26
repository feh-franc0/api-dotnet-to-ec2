namespace ApiSeguidores.Models;


public class CreateSeguidorDto
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public TimeSpan Hora { get; set; }
}

public class UpdateSeguidorDto
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public TimeSpan Hora { get; set; }
}