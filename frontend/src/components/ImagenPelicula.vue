<template>
  <div class="contenedor-imagen" v-if="pelicula">
    <img :src="`/multimedia/${pelicula?.imagen}`" :alt="pelicula?.titulo">
    <div class="degradado"></div>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { useSesionesStore } from '../store/SesionStore';

const sesionesStore = useSesionesStore();
const pelicula = computed(() => sesionesStore.pelicula);
</script>

<style scoped>
.contenedor-imagen {
  position: absolute;
  right: 0;
  top: 0;
  height: 100vh;
  width: 30%;
  z-index: 0; 
}

.contenedor-imagen img {
  height: 100%;
  object-fit: cover;
  width: 100%;
  z-index: 1;
}

.degradado {
  position: absolute;
  left: 0;
  top: 0;
  bottom: 0;
  width: 100%;
  background: linear-gradient(to right, rgba(0, 0, 0, 1) 0%, transparent 100%);
  z-index: 2;
}

@media (max-width: 768px) {
  .contenedor-imagen {
    width: 50%; 
  }
}
</style>