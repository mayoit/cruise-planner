#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FishingTrip.API/FishingTrip.API. ", "FishingTrip.API/"]
RUN dotnet restore "FishingTrip.API/FishingTrip.API.csproj"
COPY . .
WORKDIR "/src/FishingTrip.API"
RUN dotnet build "FishingTrip.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FishingTrip.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FishingTrip.API.dll"]