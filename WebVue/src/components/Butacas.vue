<template>
<div class="all">
    <div id="movieDetails">
        <a href="pay.html"><button id="comprarBtnDesktop">Comprar</button></a>
        <div class="dinero">
            <div id="precioPorButaca">Precio por butaca: 10€</div>
            <div id="total">Total: 0€</div>
        </div>
    </div>    

    <div id="contenedorButacas">
    <br>
    <div class="pantalla"></div>
    </div>
    
</div>
    
    <div id="movieContainer"></div>
    <div id="transactionHistory"></div>
    <button id="comprarBtnMobile" @click="">Comprar</button>



</template>



<style scoped>
body {
  font-family: "Helvetica";
  margin: 0;
  padding: 0;
  background-color: #000;
  color: #fff;
  height: 100vh;
  height: calc(100vh - 90px);
  overflow-y: hidden;
  background: linear-gradient(to right, rgba(0, 0, 0, 0.5), transparent), url("multimedia/cinefondodegradado.png") center/cover no-repeat;
  background-position: right center; 
}

.all {
  margin-top: 40px;
  display: flex;
}

#moviePoster {
  max-width: 70%;
  height: auto;
  width: 45%;
  margin-top: 20px;
}

#contenedorButacas {
  margin-left: 23%;
  margin-top: 3%;
  display: flex;
  flex-wrap: wrap; 
  justify-content: space-between; 
  align-items: center;
  background-color: rgba(128, 128, 128, 0.5);
  border-radius: 20px;
  padding: 20px;
  height: 600px;
  width: 40%;
}

.bloque {
  display: flex;
  flex-direction: column; 
}

.spacer {
  width: 20px; 
  height: 100%; 
}

.butaca.selected {
  background-color: #008CBA;
}

.butaca.ocupada {
  background-color: #FF0000;
}

.butaca.comprada {
  background-color: red;
}

#movieContainer {
  padding: 10px;
}

a {
  text-decoration: none;
  color: white;
  transition: transform 0.2s ease-in-out;
}

a:hover {
  transform: scale(1.1);
}

#transactionHistory {
  padding: 20px;
}

.butaca {
  width: 50px;
  height: 50px;
  margin: 5px 10px;
  background-color: #ffffff;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  font-size: 14px;
  transition: background-color 0.3s;
}

.pantalla {
  background-color: rgb(0, 0, 0);
  width: 2000px;
  height: 40px;
}

.movieDetails, img {
  max-width: 370px;
  margin-top: 18%;
  margin-left: 99%;
}

.dinero {
  margin-left: 50px;
}

#comprarBtnDesktop {
  font-family: "Helvetica";
  margin-top: 20px;
  margin-left: 116%;
  height: 50px;
  width: 60%;
  background-color: #ff0000;
  color: #ffffff;
  border: none;
  cursor: pointer;
  font-size: 16px;
  display: block;
  border-radius: 100px;
}

#comprarBtnDesktop:hover {
  font-size: 20px;
}
</style>