#Instalar las herramientas dotnet para ejecutar los comandos
dotnet tool install --global dotnet-ef --version 6.0.0


#Lanzar el docker-compose build para lanzar la api web y bbdd contenerizadas
docker-compose up --build


#Actualizar la base de datos con los cambios realizados
dotnet ef migrations add MigracionNuevosUusariosAdmin -p ./Data/Data.csproj -s ./Api/Api.csproj
