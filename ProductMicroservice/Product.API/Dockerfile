FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductMicroservice/Product.API/Product.API.csproj", "ProductMicroservice/Product.API/"]
COPY ["ProductMicroservice/Product.ApplicationCore/Product.ApplicationCore.csproj", "ProductMicroservice/Product.ApplicationCore/"]
COPY ["ProductMicroservice/Product.Infrastructure/Product.Infrastructure.csproj", "ProductMicroservice/Product.Infrastructure/"]
RUN dotnet restore "ProductMicroservice/Product.API/Product.API.csproj"
COPY . .
WORKDIR "/src/ProductMicroservice/Product.API"
RUN dotnet build "Product.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Product.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.API.dll"]
