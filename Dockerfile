FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["ScrobbleBot.CLI/ScrobbleBot.CLI.csproj", "ScrobbleBot.CLI/"]
RUN dotnet restore "ScrobbleBot.CLI/ScrobbleBot.CLI.csproj"
COPY . .
WORKDIR /src/ScrobbleBot.CLI
RUN dotnet build "ScrobbleBot.CLI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScrobbleBot.CLI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScrobbleBot.CLI.dll"]
