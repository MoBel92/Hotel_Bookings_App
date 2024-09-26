# Use the official .NET 8.0 runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET 8.0 SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["API/API.csproj", "API/"]
RUN dotnet restore "API/API.csproj"

# Install EF Tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy the rest of the application code and build it
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# Set up the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run migrations
RUN dotnet ef database update

ENTRYPOINT ["dotnet", "API.dll"]
