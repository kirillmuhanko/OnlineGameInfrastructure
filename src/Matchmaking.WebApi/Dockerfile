﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Matchmaking.WebApi/Matchmaking.WebApi.csproj", "Matchmaking.WebApi/"]
RUN dotnet restore "Matchmaking.WebApi/Matchmaking.WebApi.csproj"
COPY src .
WORKDIR "/src/Matchmaking.WebApi"
RUN dotnet build "Matchmaking.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Matchmaking.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matchmaking.WebApi.dll"]
