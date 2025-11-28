FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ferreteria.Api/Ferreteria.Api.csproj", "Ferreteria.Api/"]
COPY ["src/Ferreteria.Infrastructure/Ferreteria.Infrastructure.csproj", "src/Ferreteria.Infrastructure/"]
COPY ["src/Ferreteria.Application/Ferreteria.Application.csproj", "src/Ferreteria.Application/"]
COPY ["src/Ferreteria.Domain/Ferreteria.Domain.csproj", "src/Ferreteria.Domain/"]
RUN dotnet restore "Ferreteria.Api/Ferreteria.Api.csproj"
COPY . .
WORKDIR "/src/Ferreteria.Api"
RUN dotnet build "./Ferreteria.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ferreteria.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ferreteria.Api.dll"]
