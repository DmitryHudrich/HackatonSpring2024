# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY *.sln .

COPY ServerApp.Api/*.csproj ./ServerApp.Api/
COPY ServerApp.DataBase/*.csproj ./ServerApp.DataBase/
COPY ServerApp.Logic/*.csproj ./ServerApp.Logic/
COPY ServerApp.Application/*.csproj ./ServerApp.Application/

# copy everything else and build app
COPY ServerApp.Api/. ./ServerApp.Api/
COPY ServerApp.DataBase/. ./ServerApp.DataBase/
COPY ServerApp.Logic/. ./ServerApp.Logic/
COPY ServerApp.Application/. ./ServerApp.Application/

WORKDIR /source/ServerApp.Api
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ServerApp.Api.dll"]

