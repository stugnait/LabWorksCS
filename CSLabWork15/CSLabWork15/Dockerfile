FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CSLabWork15/CSLabWork15.csproj", "CSLabWork15/"]
RUN dotnet restore "CSLabWork15/CSLabWork15.csproj"
COPY . .
WORKDIR "/src/CSLabWork15"
RUN dotnet build "CSLabWork15.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSLabWork15.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSLabWork15.dll"]
