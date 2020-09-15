FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY "ProvaF.sln" "ProvaF.sln"
COPY "ProvaF.API/ProvaF.API.csproj" "ProvaF.API/ProvaF.API.csproj"
COPY "ProvaF.API.Tests/ProvaF.API.Tests.csproj" "ProvaF.API.Tests/ProvaF.API.Tests.csproj"
COPY "ProvaF.Domain/ProvaF.Domain.csproj" "ProvaF.Domain/ProvaF.Domain.csproj"
COPY "ProvaF.Infrastructure/ProvaF.Infrastructure.csproj" "ProvaF.Infrastructure/ProvaF.Infrastructure.csproj"
COPY "ProvaF.Domain.Tests/ProvaF.Domain.Tests.csproj" "ProvaF.Domain.Tests/ProvaF.Domain.Tests.csproj"
RUN dotnet restore

COPY . .
WORKDIR /src/ProvaF.API
RUN dotnet publish -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProvaF.API.dll"]