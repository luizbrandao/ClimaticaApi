namespace AmbienteApi.Repositories.Ambiente;

public class AmbienteDto
{
    public int Id { get; set; }
    public decimal Temperatura { get; set; }
    public decimal Umidade { get; set; }
    public decimal Pressao { get; set; }
    public decimal Luminosidade { get; set; }
    public DateTime? Data { get; set; }
    public bool? Interno { get; set; }
}