# Use the official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["StartMyNewApp/StartMyNewApp.csproj", "StartMyNewApp/"]
RUN dotnet restore "StartMyNewApp/StartMyNewApp.csproj"

# Copy the rest of the application code and build it
COPY . .
WORKDIR "/src/StartMyNewApp"
RUN dotnet build "StartMyNewApp.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "StartMyNewApp.csproj" -c Release -o /app/publish

# Set up the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StartMyNewApp.dll"]
