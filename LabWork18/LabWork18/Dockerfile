FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LabWork18/LabWork18.csproj", "LabWork18/"]
RUN dotnet restore "LabWork18/LabWork18.csproj"
COPY . .
WORKDIR "/src/LabWork18"
RUN dotnet build "LabWork18.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabWork18.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabWork18.dll"]
