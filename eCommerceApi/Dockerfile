#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eCommerceApi/eCommerceApi.csproj", "eCommerceApi/"]
COPY ["Libraries/Business/Business.csproj", "Libraries/Business/"]
COPY ["Libraries/DataAccess/DataAccess.csproj", "Libraries/DataAccess/"]
COPY ["Libraries/Core/Core.csproj", "Libraries/Core/"]
COPY ["Libraries/Entities/Entities.csproj", "Libraries/Entities/"]
RUN dotnet restore "./eCommerceApi/./eCommerceApi.csproj"
COPY . .
WORKDIR "/src/eCommerceApi"
RUN dotnet build "./eCommerceApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerceApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerceApi.dll"]