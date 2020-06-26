FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Weather.Web.csproj", "."]
RUN dotnet restore "Weather.Web.csproj"
COPY . .
RUN dotnet build "Weather.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.Web.dll"]