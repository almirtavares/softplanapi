FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SoftplanAPI1.csproj", "./"]
RUN dotnet restore "./SoftplanAPI1.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SoftplanAPI1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftplanAPI1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftplanAPI1.dll"]
