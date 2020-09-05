FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers

COPY ./Application/*.csproj ./Application/
COPY ./clients.Api/*.csproj ./clients.Api/
COPY ./Data/*.csproj ./Data/
COPY ./Domain/*.csproj ./Domain/
COPY *.sln ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
WORKDIR /app/clients.Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/clients.Api/out .
ENTRYPOINT ["dotnet", "clients.Api.dll"]
