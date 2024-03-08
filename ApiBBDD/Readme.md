dotnet tool install --global dotnet-ef --version 6.0.0
docker-compose up --build
dotnet ef migrations add 20240221101044_agregandotablabutacas -p ./Data/Data.csproj -s ./Api/Api.csproj
dotnet ef database update -p ./Data/Data.csproj -s ./Api/Api.csproj



Tabla Usuarios
    UsuarioID (Clave primaria)
    Nombre
    CorreoElectronico
    Rol (Puede ser 'Usuario' o 'Administrador')

Tabla Salas
    SalaID (Clave primaria)
    NombreSala
    Capacidad

Tabla Butacas
    ButacaID (Clave primaria)
    SalaID (Clave foránea que referencia a Salas.SalaID)
    Estado (Puede ser 'Disponible' o 'Ocupada')
    NumeroButaca

Tabla Películas
    PeliculaID (Clave primaria)
    Imagen
    Titulo
    Director
    Actores
    Descripcion

Tabla Sesiones (Reemplaza a la tabla Funciones)
    SesionID (Clave primaria)
    PeliculaID (Clave foránea que referencia a Películas.PeliculaID)
    SalaID (Clave foránea que referencia a Salas.SalaID)
    FechaHora (Fecha y hora de la sesión)
Relaciones:
Salas - Butacas: Cada Sala puede tener muchas Butacas (relación 1 a muchos). La clave foránea SalaID en la tabla Butacas establece esta relación.

Salas - Sesiones: Cada Sala puede tener varias Sesiones programadas para diferentes películas y horarios (relación 1 a muchos). La clave foránea SalaID en la tabla Sesiones establece esta relación.

Películas - Sesiones: Cada Película puede ser proyectada en varias Sesiones a través de diferentes salas y en distintos horarios (relación 1 a muchos). La clave foránea PeliculaID en la tabla Sesiones establece esta relación.

Esta estructura permite una gestión completa y flexible de un cine, facilitando la administración de usuarios, el seguimiento del estado de las butacas, la gestión de las películas, y la organización de las sesiones donde se proyectan estas películas en las salas, todo ello manteniendo una clara relación entre las entidades involucradas.