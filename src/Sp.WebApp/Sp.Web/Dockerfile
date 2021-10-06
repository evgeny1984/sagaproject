#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm

WORKDIR /src

COPY ["src/Sp.WebApp/Sp.Web/Sp.Web.csproj", "src/Sp.WebApp/Sp.Web/"]
COPY ["src/Sp.Common/DataContracts/Sp.Dto/Sp.Dto.csproj", "src/Sp.Common/DataContracts/Sp.Dto/"]
RUN dotnet restore "src/Sp.WebApp/Sp.Web/Sp.Web.csproj"
COPY . .
WORKDIR "/src/src/Sp.WebApp/Sp.Web"
RUN dotnet build "Sp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sp.Web.dll"]