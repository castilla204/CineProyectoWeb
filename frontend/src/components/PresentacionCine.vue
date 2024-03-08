<template>
  <div class="home">
    <div class="izquierda">
      <img :src="'multimedia/fotopalomitas.png'" alt="Palomitas de maíz" class="fotopalomitas">
    </div>
    <div class="derecha">
      <div class="textopresentacion">
        <p class="f1">ZARAGOZA</p>
        <p class="f2">CINES FLIX</p>
        <p class="f3">Cines Flex, la mejor opción de disfrute audiovisual en toda la ciudad de Zaragoza. Ven a conocernos.</p>
        <button class="botonhome" @click="AccionScrollDown">COMPRAR</button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import Cartelera from './Cartelera.vue';

const AccionScrollDown = () => {
  window.scrollBy({ top: 1000, behavior: 'smooth' });
};
</script>

<style scoped>
.home {
  display: flex;
  justify-content: space-between;
  margin-top: 5%;
  margin-bottom: 5%;
}

.izquierda {
  margin-left: 12%;
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

.f2 {
  color: white;
  font-family: 'HelveticaBold';
  font-size: 110px;
  margin: 0;
}

body {
  padding: 0;
  margin: 0;
  background: black;
  font-family: 'Helvetica';
}

.f3 {
  color: white;
  font-family: 'HelveticaThin';
  font-size: 28px;
  margin: 0;
  margin-left: 1%;
  max-width: 70%;
}

.izquierda img {
  height: 600px;
}

@media screen and (max-width: 768px) {
  .home {
    flex-direction: column;
    align-items: center;
    margin-top: 20px;
    margin-bottom: 20px;
  }

  .izquierda,
  .derecha {
    width: 100%;
    text-align: center;
    margin-left: 0;
  }

  .fotopalomitas {
    display: none;
  }

  .textopresentacion {
    margin-top: 10%;
    margin-left: 0;
  }

  .f1,
  .f2,
  .f3 {
    font-size: 40px;
    margin: 0;
    max-width: 100%;
  }

  .f3 {
    display: block;
    font-size: 20px;
  }

  .botonhome {
    margin-top: 20px;
    margin-left: 0;
  }
}
</style>