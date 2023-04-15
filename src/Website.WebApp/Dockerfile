FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Install Node.js
RUN curl -fsSL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y \
        nodejs \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /src
COPY ["src/Website.WebApp/Website.WebApp.csproj", "Website.WebApp/"]
RUN dotnet restore "Website.WebApp/Website.WebApp.csproj"
COPY src .
WORKDIR "/src/Website.WebApp"
RUN dotnet build "Website.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Website.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Website.WebApp.dll"]
