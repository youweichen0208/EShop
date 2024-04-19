FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderMicroservice/Order.API/Order.API.csproj", "OrderMicroservice/Order.API/"]
COPY ["OrderMicroservice/Order.Infrastructure/Order.Infrastructure.csproj", "OrderMicroservice/Order.Infrastructure/"]
COPY ["OrderMicroservice/Order.ApplicationCore/Order.ApplicationCore.csproj", "OrderMicroservice/Order.ApplicationCore/"]
RUN dotnet restore "OrderMicroservice/Order.API/Order.API.csproj"
COPY . .
WORKDIR "/src/OrderMicroservice/Order.API"
RUN dotnet build "Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Order.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.API.dll"]
