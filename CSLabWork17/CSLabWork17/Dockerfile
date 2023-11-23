FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CSLabWork17/CSLabWork17.csproj", "CSLabWork17/"]
RUN dotnet restore "CSLabWork17/CSLabWork17.csproj"
COPY . .
WORKDIR "/src/CSLabWork17"
RUN dotnet build "CSLabWork17.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSLabWork17.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSLabWork17.dll"]
