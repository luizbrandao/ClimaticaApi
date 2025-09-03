using AmbienteApi.migrations.Context;
using AmbienteApi.Profiles;
using AmbienteApi.Repositories.Ambiente;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbClimaticaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbClimaticaContext")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAmbienteRepository, AmbienteRepository>();
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AmbienteProfile>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();