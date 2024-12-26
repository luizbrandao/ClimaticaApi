using AmbienteApi.migrations.Entities;
using AmbienteApi.Repositories.Ambiente;
using GraphQL;
using GraphQL.Types;

namespace AmbienteApi.Schema;

public class RegistroQuery : ObjectGraphType<List<Registro>>
{
    public RegistroQuery(IAmbienteRepository ambienteRepository)
    {
        Name = "RegistroQuery";
        Field<ListGraphType<RegistroType>>("registros")
            .ResolveAsync(async context => await ambienteRepository.Ultimas24HrsAsync());
        Field<RegistroType>("registro")
            .Arguments(new QueryArguments(new QueryArguments()
            {
                new QueryArgument<IdGraphType>() { Name = "id" } 
            }))
            .ResolveAsync(async context => 
            {
                var id = context.GetArgument<int>("id");
                return await ambienteRepository.GetRegistroAsync(id);
            });
    }
}