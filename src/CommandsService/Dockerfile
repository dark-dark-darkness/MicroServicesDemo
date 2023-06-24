FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /
COPY ["Directory.Build.props",""]
COPY ["Directory.Packages.props" ,""]
COPY ["NuGet.Config" ,""]
COPY ["src/CommandsService/CommandsService.csproj", "src/CommandsService/"]
COPY ["src/PlatformsService.Shared/PlatformsService.Shared.csproj", "src/PlatformsService.Shared/"]
COPY ["src/CommandsService.Shared/CommandsService.Shared.csproj", "src/CommandsService.Shared/"]
RUN dotnet restore "src/CommandsService/CommandsService.csproj"
COPY . .
WORKDIR "/src/CommandsService"
RUN dotnet build "CommandsService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommandsService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommandsService.dll"]
