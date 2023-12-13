FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CSLabWork15.4/CSLabWork15.4.csproj", "CSLabWork15.4/"]
RUN dotnet restore "CSLabWork15.4/CSLabWork15.4.csproj"
COPY . .
WORKDIR "/src/CSLabWork15.4"
RUN dotnet build "CSLabWork15.4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSLabWork15.4.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSLabWork15.4.dll"]
