FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Weather.Internal.Api.csproj", "."]
RUN dotnet restore "Weather.Internal.Api.csproj"
COPY . .
RUN dotnet build "Weather.Internal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.Internal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.Internal.Api.dll"]