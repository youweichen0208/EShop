# Use the .NET SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 

# Set the working directory
WORKDIR /src

# Copy the project files into the Docker image
COPY ["Product.API.csproj", "./"]
COPY ["../ProductMicroservice.ApplicationCore/ProductMicroservice.ApplicationCore.csproj", "../ProductMicroservice.ApplicationCore/"]
COPY ["../ProductMicroservice.Infrastructure/ProductMicroservice.Infrastructure.csproj", "../ProductMicroservice.Infrastructure/"]

# Restore the .NET packages
RUN dotnet restore "./Product.API.csproj"

# Copy the rest of the files
COPY . .

# Set the working directory to the API project
WORKDIR "/src"