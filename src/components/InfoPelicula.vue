<template>
    <body>
        <div id="movieDetails" class="movieDetails">
        <!-- Contenedor para texto e imagen -->
        <div class="text-image-container">
            <!-- Aquí puedes mostrar la información de la película, incluida la imagen -->
            <div id="movieImage" class="image-container">
                <div class="gradient-overlay"></div>
                <img src="/imagenes/tu-imagen.jpg" class="image" alt="Nombre de la película">
            </div>
            <div class="text-container">
                <h1 id="movieTitle">Título de la Película</h1>
                <p id="movieDescription">Descripción de la película.</p>
                <!-- Otros detalles de la película... -->
            </div>
        </div>
        <button id="boton">Comprar</button>
    </div>
    </body>
</template>
<style>
body {
  font-family: "HelveticaThin";
  margin: 0;
  background-color: black;
  background-size: contain;
  background-position: right;
  background-attachment: fixed;
  background-repeat: no-repeat;
}

.text-container {
  max-width: 50%;
  color: rgb(255, 255, 255);
  font-size: 25px;
  margin-top: 200px;
  margin-left: 300px;
  overflow-wrap: break-word;
}

.h1 {
  font-family: "HelveticaBold";
}

.image {
  position: relative;
  overflow: hidden;
  border-radius: 10px; /* O cualquier otro estilo que desees */
  /* Establece el tamaño y posición de la imagen */
  width: 100%;
  height: auto;
}

.image::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(to left, rgba(0, 0, 0, 0) 50%, rgb(0, 0, 0) 100%);
}

#boton {
  margin-top: 80px;
  margin-left: 300px;
  padding: 20px 50px;
  border-radius: 100px;
  background-color: red;
  color: white;
  font-size: 18px;
}

/* Media query para pantallas más pequeñas */
@media screen and (max-width: 767px) {
  /* HEADER*/
  body {
    text-align: center;
    background: none;
    background-color: rgb(255, 255, 255);
  }
  .left,
  .right {
    margin: 10px;
  }
  .header {
    flex-direction: column;
    align-items: center;
    height: auto;
  }
  .logocine {
    display: none;
  }
  .izquierda {
    display: none;
  }
  .right {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    list-style: none;
    color: white;
    font-size: 20px;
    margin-right: 8%;
    margin-top: 10px;
    text-align: center;
  }
  .right ul {
    padding: 0; /* Elimina el relleno predeterminado del ul */
    margin: 0; /* Elimina el margen predeterminado del ul */
  }
  .right li {
    margin: 10px;
  }
  .text-container {
    color: rgb(255, 255, 255);
    margin-top: 30%;
    margin-left: 300px;
  }
  .rigth {
    font-family: "Helvetica";
  }
  body {
    margin: 0;
    padding: 0;
    background-image: none;
    background-color: black;
  }
  .text-container {
    max-width: 100%;
    font-size: 16px;
    margin-left: 10px;
  }
  #boton {
    margin-left: 10px;
    padding: 10px 20px;
    margin-top: 10px;
  }
  .text-container {
    color: rgb(255, 255, 255);
    margin-top: 30%;
    margin-left: 300px;
  }
  body {
    margin: 0;
    padding: 0;
    background-image: none;
    background-color: black;
  }
  .text-container {
    font-family: "Helvetica";
    margin-top: 20%;
    max-width: 100%;
    font-size: 16px;
    margin-left: 10px;
  }
  #boton {
    margin-left: 10px;
    padding: 10px 20px;
    margin-top: 10px;
  }
  .image {
    display: none; /* Oculta la imagen en dispositivos móviles */
  }
}
</style>