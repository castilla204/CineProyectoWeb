docker-compose up --build
dotnet ef migrations add 20240216113750_migracioninicial -p ./Data/Data.csproj -s ./Api/Api.csproj
dotnet ef database update -p ./Data/Data.csproj -s ./Api/Api.csproj