FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV Eshop="Data Source=172.17.0.3,1433;Initial Catalog=EshopDB;User=SA;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["User.API/User.API.csproj", "User.API/"]
COPY ["UserMicroservice.ApplicationCore/UserMicroservice.ApplicationCore.csproj", "UserMicroservice.ApplicationCore/"]
COPY ["UserMicroservice.Infrastructure/UserMicroservice.Infrastructure.csproj", "UserMicroservice.Infrastructure/"]
RUN dotnet restore "User.API/User.API.csproj"
COPY . .
WORKDIR "/src/User.API"
RUN dotnet build "User.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "User.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]
