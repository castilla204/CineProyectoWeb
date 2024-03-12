#Instalar las herramientas dotnet para ejecutar los comandos
dotnet tool install --global dotnet-ef --version 6.0.0


#Lanzar el docker-compose build para lanzar la api web y bbdd contenerizadas
docker-compose up --build


#Actualizar la base de datos con los cambios realizados
dotnet ef migrations database update -p ./Data/Data.csproj -s ./Api/Api.csproj


#Ingresar al contenedor para ver los Logs almacenados en la carpeta Logs:
docker exec -it <idcontendirapi> bash



#Nueva migracion(en caso de que se quiera realizar)
dotnet ef migrations add <NombreMigracion> -p ./Data/Data.csproj -s ./Api/Api.csproj
