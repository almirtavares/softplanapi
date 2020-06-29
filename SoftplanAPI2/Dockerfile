FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SoftplanAPI2.csproj", "./"]
RUN dotnet restore "./SoftplanAPI2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SoftplanAPI2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftplanAPI2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftplanAPI2.dll"]
