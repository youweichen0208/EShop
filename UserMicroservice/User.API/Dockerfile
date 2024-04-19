FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserMicroservice/User.API/User.API.csproj", "UserMicroservice/User.API/"]
COPY ["UserMicroservice/User.ApplicationCore/User.ApplicationCore.csproj", "UserMicroservice/User.ApplicationCore/"]
COPY ["UserMicroservice/User.Infrastructure/User.Infrastructure.csproj", "UserMicroservice/User.Infrastructure/"]
RUN dotnet restore "UserMicroservice/User.API/User.API.csproj"
COPY . .
WORKDIR "/src/UserMicroservice/User.API"
RUN dotnet build "User.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "User.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]
