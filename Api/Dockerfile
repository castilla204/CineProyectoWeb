
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ../*.sln .
COPY ../Modelos/*.csproj Modelos/
COPY ../Business/*.csproj Business/
COPY ../Data/*.csproj Data/
COPY Api/*.csproj Api/
RUN dotnet restore


COPY . .


RUN dotnet publish Api/Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "Api.dll"]

