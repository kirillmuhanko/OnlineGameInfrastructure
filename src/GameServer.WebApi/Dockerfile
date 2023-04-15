FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GameServer.WebApi/GameServer.WebApi.csproj", "GameServer.WebApi/"]
RUN dotnet restore "src/GameServer.WebApi/GameServer.WebApi.csproj"
COPY . .
WORKDIR "/src/GameServer.WebApi"
RUN dotnet build "GameServer.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameServer.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameServer.WebApi.dll"]
