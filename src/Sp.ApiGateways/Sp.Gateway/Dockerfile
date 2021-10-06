FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Cc.ApiGateways/Cc.Gateway/Cc.Gateway.csproj", "src/Cc.ApiGateways/Cc.Gateway/"]
RUN dotnet restore "src/Cc.ApiGateways/Cc.Gateway/Cc.Gateway.csproj"
COPY . .
WORKDIR "/src/src/Cc.ApiGateways/Cc.Gateway"
RUN dotnet build "Cc.Gateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Cc.Gateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Cc.Gateway.dll"]
