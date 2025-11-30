# ==========================
# Etapa de build
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copiar la solución y los proyectos .csproj para restaurar dependencias
COPY *.sln ./
COPY SistemaViajes.API/*.csproj ./SistemaViajes.API/
COPY SistemaViajes.BusinessLogic/*.csproj ./SistemaViajes.BusinessLogic/
COPY SistemaViajes.DataAccess/*.csproj ./SistemaViajes.DataAccess/
COPY SistemaViajes.Models/*.csproj ./SistemaViajes.Models/

# Restaurar paquetes NuGet
RUN dotnet restore

# Copiar todo el código fuente
COPY . .

# Publicar la API en modo Release
RUN dotnet publish SistemaViajes.API/SistemaViajes.API.csproj -c Release -o /app/out

# ==========================
# Etapa runtime
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build-env /app/out .

# Configurar el entrypoint
ENTRYPOINT ["dotnet", "SistemaViajes.API.dll"]
