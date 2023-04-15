FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Storage.WebApi/Storage.WebApi.csproj", "Storage.WebApi/"]
RUN dotnet restore "src/Storage.WebApi/Storage.WebApi.csproj"
COPY . .
WORKDIR "/src/Storage.WebApi"
RUN dotnet build "Storage.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Storage.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Storage.WebApi.dll"]
