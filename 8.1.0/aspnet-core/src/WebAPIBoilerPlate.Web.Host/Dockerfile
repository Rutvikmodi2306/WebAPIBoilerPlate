FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/WebAPIBoilerPlate.Web.Host/WebAPIBoilerPlate.Web.Host.csproj", "src/WebAPIBoilerPlate.Web.Host/"]
COPY ["src/WebAPIBoilerPlate.Web.Core/WebAPIBoilerPlate.Web.Core.csproj", "src/WebAPIBoilerPlate.Web.Core/"]
COPY ["src/WebAPIBoilerPlate.Application/WebAPIBoilerPlate.Application.csproj", "src/WebAPIBoilerPlate.Application/"]
COPY ["src/WebAPIBoilerPlate.Core/WebAPIBoilerPlate.Core.csproj", "src/WebAPIBoilerPlate.Core/"]
COPY ["src/WebAPIBoilerPlate.EntityFrameworkCore/WebAPIBoilerPlate.EntityFrameworkCore.csproj", "src/WebAPIBoilerPlate.EntityFrameworkCore/"]
WORKDIR "/src/src/WebAPIBoilerPlate.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/WebAPIBoilerPlate.Web.Host", "src/WebAPIBoilerPlate.Web.Host"]
COPY ["src/WebAPIBoilerPlate.Web.Core", "src/WebAPIBoilerPlate.Web.Core"]
COPY ["src/WebAPIBoilerPlate.Application", "src/WebAPIBoilerPlate.Application"]
COPY ["src/WebAPIBoilerPlate.Core", "src/WebAPIBoilerPlate.Core"]
COPY ["src/WebAPIBoilerPlate.EntityFrameworkCore", "src/WebAPIBoilerPlate.EntityFrameworkCore"]
WORKDIR "/src/src/WebAPIBoilerPlate.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "WebAPIBoilerPlate.Web.Host.dll"]
