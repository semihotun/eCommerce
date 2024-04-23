#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eCommerce/eCommerce.csproj", "eCommerce/"]
COPY ["Libraries/Core/Core.csproj", "Libraries/Core/"]
COPY ["Libraries/Business/Business.csproj", "Libraries/Business/"]
COPY ["Libraries/DataAccess/DataAccess.csproj", "Libraries/DataAccess/"]
COPY ["Libraries/Entities/Entities.csproj", "Libraries/Entities/"]
COPY ["Plugins/Plugin.Base/Plugin.Base.csproj", "Plugins/Plugin.Base/"]
COPY ["Plugins/Plugin.Iyzico/Plugin.Iyzico.csproj", "Plugins/Plugin.Iyzico/"]
RUN dotnet restore "./eCommerce/./eCommerce.csproj"
COPY . .
WORKDIR "/src/eCommerce"
RUN dotnet build "./eCommerce.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerce.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.dll"]