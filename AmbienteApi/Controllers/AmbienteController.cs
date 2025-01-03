using AmbienteApi.Repositories.Ambiente;
using Microsoft.AspNetCore.Mvc;

namespace AmbienteApi.Controllers;

[Route("[controller]")]
[ApiController]
public class AmbienteController : ControllerBase
{
    private readonly IAmbienteRepository _ambienteRepository;
    
    public AmbienteController(IAmbienteRepository ambienteRepository)
    {
        _ambienteRepository = ambienteRepository;
    }
    
    [HttpGet("GetRegistro")]
    public async Task<IActionResult> GetRegistro(int id)
    {
        return Ok(await _ambienteRepository.GetRegistroAsync(id));
    }

    [HttpGet("dados")]
    public async Task<IActionResult> Dados()
    {
        return Ok(await _ambienteRepository.Ultimas24HrsAsync());
    }
    
    [HttpGet("ultimo-registro")]
    public async Task<IActionResult> Index()
    {
        return Ok(await _ambienteRepository.GetUltimoRegistroAsync());
    }

    [HttpPost("GravarRegistros")]
    public async Task<IActionResult> GravarRegistro([FromBody] AmbienteDto ambienteDto)
    {
        return Ok(await _ambienteRepository.GravarRegistroAsync(ambienteDto));
    }
}