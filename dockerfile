FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia los archivos de solución y proyectos y restaura las dependencias
# Lista los .csproj para asegurar la restauración adecuada de dependencias entre proyectos.
COPY ["Lab13Chavez.API/Lab13Chavez.API.csproj", "Lab13Chavez.API/"]
COPY ["Lab13Chavez.Application/Lab13Chavez.Application.csproj", "Lab13Chavez.Application/"]
COPY ["Lab13Chavez.Domain/Lab13Chavez.Domain.csproj", "Lab13Chavez.Domain/"]
COPY ["Lab13Chavez.Infrastructure/Lab13Chavez.Infrastructure.csproj", "Lab13Chavez.Infrastructure/"]
COPY ["Lab13Chavez.sln", "."]

RUN dotnet restore "Lab13Chavez.sln"


COPY . .
RUN dotnet build "Lab13Chavez.sln" -c Release -o /app/build


FROM build AS publish

RUN dotnet publish "Lab13Chavez.API/Lab13Chavez.API.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copia los archivos publicados desde el stage 'publish'
COPY --from=publish /app/publish .

# Define el punto de entrada (el .dll del proyecto API)
ENTRYPOINT ["dotnet", "Lab13Chavez.API.dll"]