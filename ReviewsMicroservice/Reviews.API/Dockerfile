FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReviewsMicroservice/Reviews.API/Reviews.API.csproj", "ReviewsMicroservice/Reviews.API/"]
COPY ["ReviewsMicroservice/Reviews.Infrastructure/Reviews.Infrastructure.csproj", "ReviewsMicroservice/Reviews.Infrastructure/"]
COPY ["ReviewsMicroservice/Reviews.ApplicationCore/Reviews.ApplicationCore.csproj", "ReviewsMicroservice/Reviews.ApplicationCore/"]
RUN dotnet restore "ReviewsMicroservice/Reviews.API/Reviews.API.csproj"
COPY . .
WORKDIR "/src/ReviewsMicroservice/Reviews.API"
RUN dotnet build "Reviews.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Reviews.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reviews.API.dll"]
