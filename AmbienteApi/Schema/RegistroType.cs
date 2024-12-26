using AmbienteApi.migrations.Entities;
using AmbienteApi.Repositories.Ambiente;
using GraphQL.Types;

namespace AmbienteApi.Schema;

public class RegistroType : ObjectGraphType<AmbienteDto>
{
    public RegistroType()
    {
        Field(x => x.Id);
        Field(x => x.Temperatura);
        Field(x => x.Umidade);
        Field(x => x.Luminosidade);
        Field(x => x.Pressao);
        Field(x => x.Data);
        Field(x => x.Interno);
    }
}