# Etapa base: runtime ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa build: SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia os projetos individualmente para aproveitar cache
COPY ["AmbienteApi/AmbienteApi.csproj", "AmbienteApi/"]
COPY ["AmbienteApi.migrations/AmbienteApi.migrations.csproj", "AmbienteApi.migrations/"]

# Restaura dependências
RUN dotnet restore "AmbienteApi/AmbienteApi.csproj"

# Copia o restante do código
COPY . .

# Define o diretório de trabalho para o projeto principal
WORKDIR "/src/AmbienteApi"

# Compila a aplicação
RUN dotnet build "AmbienteApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa publish: gera artefatos otimizados para produção
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AmbienteApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final: imagem mínima com apenas runtime + app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmbienteApi.dll"]