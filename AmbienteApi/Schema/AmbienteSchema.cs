namespace AmbienteApi.Schema;

public class AmbienteSchema : GraphQL.Types.Schema
{
    public AmbienteSchema(IServiceProvider serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<RegistroQuery>();
    }
}