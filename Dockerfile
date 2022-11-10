FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ["Wame.Api/Wame.Api.csproj", "Wame.Api/"]
COPY ["Wame.Domain/Wame.Domain.csproj", "Wame.Domain/"]
COPY ["Wame.Application/Wame.Application.csproj", "Wame.Application/"]


RUN dotnet restore "Wame.Api/Wame.Api.csproj"
COPY . .
WORKDIR "/app/Wame.Api"

ENTRYPOINT dotnet run watch --project=Wame.Api.csproj --urls=http://+80
EXPOSE 80