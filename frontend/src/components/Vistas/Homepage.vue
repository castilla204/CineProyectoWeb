<template>
  <div class="general">
    <!-- Pantalla de carga con animación del logo -->
    <div v-if="isLoading" class="loader-container">
      <svg width="200" height="200" xmlns="http://www.w3.org/2000/svg" class="loader-logo">
        <circle cx="60" cy="65" r="30" :fill="circle1Color"/>  
        <circle cx="140" cy="55" r="40" :fill="circle2Color"/> 
        
        <rect x="50" y="100" width="100" height="100" :fill="squareColor">
          <animate attributeName="opacity" from="0" to="1" dur="1s" begin="0s" fill="freeze"/>
          <animate attributeName="x" from="-100" to="50" dur="1s" begin="0s" fill="freeze"/>
          <animate attributeName="y" from="-100" to="100" dur="1s" begin="0s" fill="freeze"/>
        </rect>

        <polygon points="100,100 100,200 150,150" :fill="triangle1Color">
          <animate attributeName="opacity" from="0" to="1" dur="1s" begin="0.5s" fill="freeze"/>
          <animate attributeName="points" dur="1s" from="75,75 75,175 125,125" to="100,100 100,200 150,150" fill="freeze"/>
        </polygon>

        <polygon points="200,100 200,200 150,150" :fill="triangle2Color">
          <animate attributeName="opacity" from="0" to="1" dur="1s" begin="1s" fill="freeze"/>
          <animate attributeName="points" dur="1s" from="275,75 275,175 225,125" to="200,100 200,200 150,150" fill="freeze"/>
        </polygon>
      </svg>
    </div>

    <!-- Contenido de la página principal -->
    <div v-else>
      <PresentacionCine @scroll-down="AccionScrollDown" />
      <Cartelera ref="componenteCartelera" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import Cartelera from '../Cartelera.vue';
import PresentacionCine from '../PresentacionCine.vue';

const componenteCartelera = ref(null as InstanceType<typeof Cartelera> | null);
const isLoading = ref(true);

const circle1Color = "#FF5733";
const circle2Color = "#FFC300";
const squareColor = "#FF5733";
const triangle1Color = "#FF9980";
const triangle2Color = "#FF3333";

const AccionScrollDown = () => {
  if (componenteCartelera.value) {
    const carteleraComponent = componenteCartelera.value.$el;
    if (carteleraComponent) {
      carteleraComponent.scrollIntoView({ behavior: 'smooth' });
    }
  }
};

onMounted(() => {
  setTimeout(() => {
    isLoading.value = false;
  }, 1800); 
});
</script>

<style scoped>
.general {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: black;
}

.loader-container {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: black; /* Cambiamos el fondo a negro */
}

.loader-logo {
  animation: spin 4s linear infinite; /* Cambia la duración y el tipo de animación según sea necesario */
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(540deg); }
}
</style>