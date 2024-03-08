<template>
  <div class="general">
    <div class="home">
      <div class="izquierda">
        <img :src="'multimedia/fotopalomitas.png'" alt="Palomitas de maíz">
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
    <cartelera ref="componenteCartelera"></cartelera>
  </div>
  </template>
<script>

import Cartelera from './Cartelera.vue'; 

export default {
  name: 'Homepage',
  components: {
    Cartelera //registro eCartelera en el componente homepage
  },
  methods: {
    AccionScrollDown() {
      const carteleraComponent = this.$refs.componenteCartelera.$el; 
      carteleraComponent.scrollIntoView({ behavior: 'smooth' }); 
    },
  },
};
</script>
    
<style scoped>
.general {
  display: flex;
  flex-direction: column;
  min-height: 100vh; 
  background-color: black; 
}


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
  /*background: linear-gradient(rgb(0, 0, 0), rgb(48, 48, 48));*/
  font-family: 'Helvetica';
}

.f3 {
  color: white;
  font-family: 'HelveticaThin';
  font-size: 28px;
  margin: 0;
  margin-left: 1%;
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


</style>
