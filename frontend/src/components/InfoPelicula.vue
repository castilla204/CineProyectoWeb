<template>
  <div class="general">
    <div class="contenido">
      <TituloDescripcionPelicula />
      <SesionesDisponibles />
    </div>
    <ImagenPelicula />
  </div>
</template>

<script setup lang="ts">
import { onMounted, watch } from 'vue';
import { useRouter } from 'vue-router';
import { useSesionesStore } from '../store/SesionStore';
import TituloDescripcionPelicula from './TituloDescripcionPelicula.vue';
import ImagenPelicula from './ImagenPelicula.vue';
import SesionesDisponibles from './SesionesDisponibles.vue';

const router = useRouter();
const sesionesStore = useSesionesStore();

onMounted(() => {
  cargarPelicula();
});

watch(router.currentRoute, () => {
  cargarPelicula();
}, { immediate: true });

function cargarPelicula() {
  const movieId = Number(router.currentRoute.value.params.movieId);
  if (!isNaN(movieId)) {
    sesionesStore.ObtenerSesionesPelicula(movieId);
  }
}
</script>


<style scoped>
.general {
  position: relative;
  display: flex; 
  flex-direction: column; 
  height: 100.4vh;
  background-color: black;
  z-index: 10; 
}

.contenido {
  width: 70%; 
  padding-right: 0;
  z-index: 2;
}

@media (max-width: 768px) {
  .contenido{
    width: 90%;
  }
}
</style>