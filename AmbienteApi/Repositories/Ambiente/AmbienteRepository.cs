using AmbienteApi.migrations.Context;
using AmbienteApi.migrations.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmbienteApi.Repositories.Ambiente;

public class AmbienteRepository : IAmbienteRepository
{
    private readonly DbClimaticaContext _dbContext;
    private readonly IMapper _mapper;
    
    public AmbienteRepository(DbClimaticaContext dbClimaticaContext,
                              IMapper mapper)
    {
        _dbContext = dbClimaticaContext;
        _mapper = mapper;
    }

    public async Task<List<AmbienteDto>> Ultimas24Hrs()
    {
        var dataLimite = DateTime.Now.AddHours(-24);

        var dados = await _dbContext.Registro
                                                 .Where(r => r.Data > dataLimite)
                                                 .ToListAsync();
        
        return _mapper.Map<List<AmbienteDto>>(dados);
    }

    public async Task<AmbienteDto> GetUltimoRegistroAsync()
    {
        var dto = await _dbContext.Registro.OrderByDescending(x => x.Data)
                                                  .FirstAsync();
        return _mapper.Map<AmbienteDto>(dto);
    }

    public async Task<bool> GravarRegistroAsync(AmbienteDto ambienteDto)
    {
        var entity = _mapper.Map<Registro>(ambienteDto);
        await _dbContext.Registro.AddAsync(entity);
        return true;
    }
}