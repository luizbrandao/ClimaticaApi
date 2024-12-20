namespace AmbienteApi.Repositories.Ambiente;

public interface IAmbienteRepository
{
    Task<List<AmbienteDto>> Ultimas24Hrs();
    Task<AmbienteDto> GetUltimoRegistroAsync();
    Task<bool> GravarRegistroAsync(AmbienteDto ambienteDto);
}