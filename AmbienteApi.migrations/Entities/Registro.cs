namespace AmbienteApi.migrations.Entities;

public class Registro
{
    public int Id { get; set; }
    public double Temperatura { get; set; }
    public double Umidade { get; set; }
    public double Pressao { get; set; }
    public double Luminosidade { get; set; }
    public DateTime? Data { get; set; }
    public bool? Interno { get; set; }
}