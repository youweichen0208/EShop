FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV Eshop="Data Source=172.17.0.2,1433;Initial Catalog=EshopDB;User=SA;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True"
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Product.API/Product.API.csproj", "Product.API/"]
COPY ["ProductMicroservice.ApplicationCore/ProductMicroservice.ApplicationCore.csproj", "ProductMicroservice.ApplicationCore/"]
COPY ["ProductMicroservice.Infrastructure/ProductMicroservice.Infrastructure.csproj", "ProductMicroservice.Infrastructure/"]
COPY ["UserMicroservice.ApplicationCore/UserMicroservice.ApplicationCore.csproj", "UserMicroservice.ApplicationCore/"]
RUN dotnet restore "Product.API/Product.API.csproj"
COPY . .
WORKDIR "/src/Product.API"
RUN dotnet build "Product.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Product.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]
