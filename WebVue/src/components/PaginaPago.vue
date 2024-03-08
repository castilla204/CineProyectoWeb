<template>

    <div class="izq">
        <form>
            <p class="subtitulo">Datos del Usuario</p>
            
            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" name="nombre" required>

            <label for="email">Email:</label>
            <input type="email" id="email" name="email" required>

            <label for="telefono">Teléfono:</label>
            <input type="tel" id="telefono" name="telefono" required>
        </form>
    </div>

    <div class="drc">
        <p class="subtitulo">Metodo de pago</p>
        <div>
            <input type="radio" id="checkbox1" name="checkbox">
            <label for="checkbox1">Tarjeta de credito</label>
            <img src="../../multimedia/visa.png" class="imagenes">
        </div>

        <div>
            <input type="radio" id="checkbox2" name="checkbox">
            <label for="checkbox2">Efectivo en el lugar</label>
            <img src="../../multimedia/dinero.png" class="imagenes">
        </div>

        <div>
            <input type="radio" id="checkbox3" name="checkbox">
            <label for="checkbox3">Paypal</label>
            <img src="../../multimedia/paypal.png" class="imagenes">
        </div>
    </div>


    <a href="index.html"><button id="boton"> Comprar</button></a>
    

</template>
<style scoped>


body {
  font-family: "Helvetica", sans-serif;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: #e4e4e4;
}


.header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  background-color: rgb(196, 0, 0);
  height: 90px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  z-index: 1000;
  width: 100%;
}
.header .logocine {
  height: 60px;
}
.header .right {
  display: flex;
  justify-content: space-between;
  list-style: none;
  color: white;
  font-size: 20px;
}
.header .right .promo,
.header .right .pelis,
.header .right .billetes {
  margin-right: 30px;
  margin-left: 30px;
}
.header .left,
.header .right {
  margin: 20px 40px;
}


.izq {
  height: 35%;
  width: 350px;
  background-color: #fff;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin: 10px;
}
.izq form {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.izq label {
  margin-bottom: 10px;
  font-size: 16px;
}
.izq input {
  padding: 10px;
  margin-bottom: 15px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 14px;
}
.izq .precio {
  font-size: 24px;
  font-weight: bold;
  color: rgb(196, 0, 0);
  margin-top: 10px;
}


.drc {
  height: 35%;
  width: 350px;
  background-color: #fff;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin: 10px;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.drc div {
  height: 20%;
  width: 80%;
  background-color: rgb(219, 219, 219);
  border-radius: 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 15px;
  padding: 0 20px;
}
.drc input {
  margin-right: 10px;
  transform: scale(1.5);
}
.drc .imagenes {
  width: 30px;
}


.subtitulo {
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 15px;
  color: rgb(196, 0, 0);
}

a {
  text-decoration: none;
  color: white;
  transition: transform 0.2s ease-in-out;
}
a:hover {
  transform: scale(1.1);
}

#boton {
  margin-top: 20px;
  padding: 15px 30px;
  font-size: 18px;
  background-color: rgb(196, 0, 0);
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}
#boton:hover {
  background-color: #990000;
}

@media only screen and (max-width: 767px) {
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
    padding: 0;
    margin: 0;
  }
  .right li {
    margin: 10px;
  }
  body {
    flex-direction: column;
  }
  .izq {
    margin-top: 30%;
    width: 80%;
  }
  .drc {
    width: 80%;
  }
}
</style>