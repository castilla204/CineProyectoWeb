<template>
    <body>
       <main class="principal">
            <div class="home">
                <div class="izquierda">
                    <img src="../../multimedia/fotopalomitas.png">
                </div>
                <div class="derecha">
                <div class="textopresentacion">
                  <p class="f1">ZARAGOZA</p>
                  <p class="f2">CINES FLIX</p>
                  <p class="f3">Cines Flex, la mejor opción de disfrute audiovisual en toda la ciudad de Zaragoza. Ven a conocernos. </p>
                  <br>
                  <button class="botonhome">COMPRAR</button>
                </div>
                    
                    
                </div>
                </div>
            </main>
    
    
            <main class="cartelera">

                    <div id="movieInfo">
                    
                    </div>
                    
                   
                    
                    <div id="ticketForm">
                        <h1 class="titulocartelera">CARTELERA</h1>
                        <p class="subtitulo1cartelera">CINE PARA TODA LA FAMILIA</p>
                        <div class="linearoja"></div>
    
                      
                        <div class="peliculas" id="movieContainer">
                            <!-- Aquí se cargarán las imágenes de las películas -->
                        </div>
                
                        <!--<button onclick="buyTickets()">COMPRAR</button>-->
                    </div>
            <!--     
                    <div id="transactionHistory">
                        Aquí se mostrará el historial de transacciones 
                    </div> -->
               
            
                </main>


</body>
</template>
<style>

/* Estilos base */
body {
  padding: 0;
  margin: 0;
  background: linear-gradient(rgb(0, 0, 0), rgb(48, 48, 48));
  font-family: 'Helvetica';
}


/* Página principal */
.principal {
  height: 100vh;
  height: calc(100vh - 90px);
  overflow-y: hidden;
  background: linear-gradient(to right, rgba(0, 0, 0, 0.5), transparent),
            url('multimedia/cinefondodegradado.png') center/cover no-repeat;
  background-position: right center;
}

.home {
  background-repeat: no-repeat;
  background-size: 60vh;
  background-position: 300px;
  display: flex;
  justify-content: space-between;
  margin-top: 5%;
}

.izquierda {
  margin-left: 12%;
}

.derecha {
}

.textopresentacion {
  margin-top: 7%;
  margin-left: 20%;
}

.f1 {
  color: white;
  font-family: 'HelveticaCursiva';
  font-size: 100px;
  margin-bottom: -28px;
  margin-left: 1%;
}

.f2 {
  color: white;
  font-family: 'HelveticaBold';
  font-size: 110px;
  margin: 0;
}

.f3 {
  color: white;
  font-family: 'HelveticaThin';
  font-size: 28px;
  margin: 0;
  margin-left: 1%;
  width: 65%;
}

.izquierda img {
  height: 600px;
}

.botonhome {
  margin-left: 1%;
  margin-top: 3%;
  font-family: 'HelveticaBold';
  display: inline-block;
  padding: 15px 30px;
  border-radius: 30px;
  background-color: red;
  color: black;
  text-decoration: none;
  border: none;
  cursor: pointer;
}
a {
  text-decoration: none; 
  color: white; 
  transition: transform 0.2s ease-in-out;
}


a:hover {
  transform: scale(1.1); 
}
/* Cartelera */
.cartelera {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: 80px;
}

.titulocartelera {
  font-size: 20px;
  margin-left: 10%;
  color: white;
  text-align: left;
}

.subtitulo1cartelera {
  font-family: 'HelveticaThin';
  margin-left: 10%;
  color: white;
  text-align: left;
  font-size: 250%;
  margin-bottom: 0%;
}

.linearoja {
  margin-left: 10%;
  width: 80%;
  height: 6px;
  background-color: darkred;
}

.peliculas img {
  width: 13%;
  margin: 30px;
}

.rounded-image {
  border-radius: 10px;
}

#ticketForm {
  width: 100%;
  text-align: center;
}

/* Media query para dispositivos móviles */
/* Media query para dispositivos móviles */
@media only screen and (max-width: 767px) {
  body {
      text-align: center; /* Centra el texto */
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
  .principal {
      height: 100vh;
      height: calc(100vh - 90px);
      overflow-y: hidden;
      background: linear-gradient(to right, rgba(0, 0, 0, 0.5), transparent),
                url('multimedia/cinefondodegradado.png') center/cover no-repeat;
      background-position: right center;
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


  .textopresentacion {
      margin: 0;
      margin-top: 40%;
  
      text-align: center; /* Centra el texto */
  }


  .f1 {
      color: white;
      font-family: 'HelveticaCursiva';
      font-size: 60px;
      margin-bottom: -23px;
      margin-left: 1%;
  }

  .f2 {
      color: white;
      font-family: 'HelveticaBold';
      font-size: 65px;
      margin: 0;
  }

  .f3 {
      color: white;
      font-family: 'HelveticaThin';
      font-size: 14px; /* Ajusta el tamaño del texto */
      margin: 0;
      margin-left: 1%;
      width: 90%;
  }

  .botonhome {
      margin: 10px 0;
      font-family: 'HelveticaBold';
      display: inline-block;
  }



  .home {
      background-position: center;
  }

  .izquierda img {
      width: 100%;
  }
  /* ... (tus estilos anteriores) */


  /*ESTILOS PARA CARTELERA*/

  .cartelera{
      margin:0;
 
  }
  .peliculas {
      margin:0;
      display: flex;
      flex-wrap: wrap;
      justify-content: space-between;
      margin: 10px; /* Ajusta según sea necesario */
  }

  .peliculas img {
      width: 30%; /* Ocupar el 48% del ancho del contenedor */
      max-width: calc(48% - 10px); /* Ajusta según sea necesario para dejar espacio entre las imágenes */
      height: 100%; /* Ajusta según sea necesario */
      object-fit: cover; /* Recorta la imagen para llenar el contenedor sin distorsión */
      margin-bottom: 10px; /* Ajusta según sea necesario */
  }


}
</style>