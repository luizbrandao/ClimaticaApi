namespace AmbienteApi.Repositories.Ambiente;

public interface IAmbienteRepository
{
    Task<List<AmbienteDto>> Ultimas24HrsAsync();
    Task<AmbienteDto> GetUltimoRegistroAsync();
    Task<bool> GravarRegistroAsync(AmbienteDto ambienteDto);
}