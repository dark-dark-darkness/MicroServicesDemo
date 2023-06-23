FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /
COPY . .
RUN dotnet restore "src/PlatformsService/PlatformsService.csproj"
WORKDIR "/src/PlatformsService"
RUN dotnet build "PlatformsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlatformsService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlatformsService.dll"]
