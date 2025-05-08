# Imagen base para tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen base para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el archivo .csproj y restauramos dependencias
COPY ["FBackend/FBackend.csproj", "FBackend/"]
RUN dotnet restore "FBackend/FBackend.csproj"

# Copiamos el resto del código y lo compilamos
COPY . .
WORKDIR "/src/FBackend"
RUN dotnet build "FBackend.csproj" -c Release -o /app/build

# Publicamos el proyecto
FROM build AS publish
RUN dotnet publish "FBackend.csproj" -c Release -o /app/publish

# Preparamos el contenedor final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Punto de entrada de la API
ENTRYPOINT ["dotnet", "FBackend.dll"]
