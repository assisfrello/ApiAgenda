FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 57100
EXPOSE 443

ENV ASPNETCORE_URLS=http//+:8000;
ENV ASPNETCORE_ENVIRONMENT=Development;

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiAgenda.Api/ApiAgenda.Api.csproj", "ApiAgenda.Api/"]
COPY ["ApiAgenda.CrossCutting/ApiAgenda.CrossCutting.csproj", "ApiAgenda.CrossCutting/"]
COPY ["ApiAgenda.Data/ApiAgenda.Data.csproj", "ApiAgenda.Data/"]
COPY ["ApiAgenda.Domain/ApiAgenda.Domain.csproj", "ApiAgenda.Domain/"]
RUN dotnet restore "ApiAgenda.Api/ApiAgenda.Api.csproj"
COPY . .
WORKDIR "/src/ApiAgenda.Api"
RUN dotnet build "ApiAgenda.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiAgenda.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiAgenda.Api.dll"]
