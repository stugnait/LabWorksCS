FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LabWork16/LabWork16.csproj", "LabWork16/"]
RUN dotnet restore "LabWork16/LabWork16.csproj"
COPY . .
WORKDIR "/src/LabWork16"
RUN dotnet build "LabWork16.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabWork16.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabWork16.dll"]
