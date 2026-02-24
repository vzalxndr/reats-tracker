# Step 1: Base Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Step 2: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file from the ReatsTracker.Api folder
COPY ["ReatsTracker.Api/ReatsTracker.Api.csproj", "ReatsTracker.Api/"]
RUN dotnet restore "ReatsTracker.Api/ReatsTracker.Api.csproj"

# Copy all other code
COPY . .
WORKDIR "/src/ReatsTracker.Api"
RUN dotnet build "ReatsTracker.Api.csproj" -c Release -o /app/build

# Step 3: Publish
FROM build AS publish
RUN dotnet publish "ReatsTracker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Step 4: Final Image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReatsTracker.Api.dll"]