using AmbienteApi.migrations.Context;
using AmbienteApi.Repositories.Ambiente;
using AmbienteApi.Schema;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbClimaticaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DbClimaticaContext")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAmbienteRepository, AmbienteRepository>();
builder.Services.AddScoped<RegistroType>();
builder.Services.AddScoped<RegistroQuery>();
builder.Services.AddScoped<ISchema, AmbienteSchema>(provider => 
    new AmbienteSchema(provider));

builder.Services.AddGraphQL(b =>
    b.AddSchema<AmbienteSchema>()
        .AddSystemTextJson()
        .AddGraphTypes()
        .AddDataLoader());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseGraphQL("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLGraphiQL(
    "/graphiql",                               // url to host GraphiQL at
    new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });
app.UseAuthorization();

app.MapControllers();

app.Run();