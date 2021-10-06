#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim  AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim  AS build
WORKDIR /src
COPY ["src/Sp.Services/Sp.CarBooking/Sp.CarBooking.Api/Sp.CarBooking.Api.csproj", "src/Sp.Services/Sp.CarBooking/Sp.CarBooking.Api/"]
RUN dotnet restore "src/Sp.Services/Sp.CarBooking/Sp.CarBooking.Api/Sp.CarBooking.Api.csproj"
COPY . .
WORKDIR "/src/src/Sp.Services/Sp.CarBooking/Sp.CarBooking.Api"
RUN dotnet build "Sp.CarBooking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sp.CarBooking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sp.CarBooking.Api.dll"]