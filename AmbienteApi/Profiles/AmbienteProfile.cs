using AmbienteApi.migrations.Entities;
using AmbienteApi.Repositories.Ambiente;
using AutoMapper;

namespace AmbienteApi.Profiles;

public class AmbienteProfile : Profile
{
    public AmbienteProfile()
    {
        CreateMap<Registro, AmbienteDto>();
        CreateMap<AmbienteDto, Registro>();
    }
}