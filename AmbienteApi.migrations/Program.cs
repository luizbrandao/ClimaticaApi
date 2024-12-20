using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AmbienteApi.migrations.Context;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContext<DbClimaticaContext>();
            });
}