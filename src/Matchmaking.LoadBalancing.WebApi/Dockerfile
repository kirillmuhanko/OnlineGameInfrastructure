FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Matchmaking.LoadBalancing.WebApi/Matchmaking.LoadBalancing.WebApi.csproj", "Matchmaking.LoadBalancing.WebApi/"]
RUN dotnet restore "Matchmaking.LoadBalancing.WebApi/Matchmaking.LoadBalancing.WebApi.csproj"
COPY src .
WORKDIR "/src/Matchmaking.LoadBalancing.WebApi"
RUN dotnet build "Matchmaking.LoadBalancing.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Matchmaking.LoadBalancing.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matchmaking.LoadBalancing.WebApi.dll"]
