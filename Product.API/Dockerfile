FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

WORKDIR /app 
EXPOSE 80 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 
WORKDIR /src
COPY ["Product.API/ProductMicroservice.csproj", "Product.API/"]
COPY ["ProductMicroservice.ApplicationCore/ProductMicroservice.ApplicationCore.csproj", "ProductMicroservice.ApplicationCore/"]
COPY ["ProductMicroservice.Infrastructure/ProductMicroservice.Infrastructure.csproj", "ProductMicroservice.Infrastructure/"]

RUN dotnet restore "Product.API/ProductMicroservice.csproj"
COPY . .
WORKDIR "/src/Product.API"
RUN dotnet build "ProductMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductMicroservice.dll"]