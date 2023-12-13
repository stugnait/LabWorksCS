FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["СSLabWork15.3/СSLabWork15.3.csproj", "СSLabWork15.3/"]
RUN dotnet restore "СSLabWork15.3/СSLabWork15.3.csproj"
COPY . .
WORKDIR "/src/СSLabWork15.3"
RUN dotnet build "СSLabWork15.3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "СSLabWork15.3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "СSLabWork15.3.dll"]
