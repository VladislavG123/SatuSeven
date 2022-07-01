FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SatuSeven.Gateways.ClientManagementSystem/SatuSeven.Gateways.ClientManagementSystem.csproj", "SatuSeven.Gateways.ClientManagementSystem/"]
RUN dotnet restore "SatuSeven.Gateways.ClientManagementSystem/SatuSeven.Gateways.ClientManagementSystem.csproj"
COPY . .
WORKDIR "/src/SatuSeven.Gateways.ClientManagementSystem"
RUN dotnet build "SatuSeven.Gateways.ClientManagementSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SatuSeven.Gateways.ClientManagementSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SatuSeven.Gateways.ClientManagementSystem.dll"]
