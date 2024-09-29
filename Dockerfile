# Use the official .NET 8.0 runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET 8.0 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY ["API/API.csproj", "API/"]
COPY ["DATA/DATA.csproj", "DATA/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infra/Infra.csproj", "Infra/"]
RUN dotnet restore "API/API.csproj"

# Copy the entire source code and build the project
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

# Publish the application
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# Set up the runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Start the application
ENTRYPOINT ["dotnet", "API.dll"]
