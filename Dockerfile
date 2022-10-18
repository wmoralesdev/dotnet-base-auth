﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Wame.Api/Wame.Api.csproj", "Wame.Api/"]
COPY ["Wame.Domain/Wame.Domain.csproj", "Wame.Domain/"]
COPY ["Wame.Application/Wame.Application.csproj", "Wame.Application/"]


RUN dotnet restore "Wame.Api/Wame.Api.csproj"
COPY . .
WORKDIR "/src/Wame.Api"
RUN dotnet build "Wame.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wame.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wame.Api.dll"]
EXPOSE 7575