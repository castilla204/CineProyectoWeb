<template>
  <div class="pelicula pelicula-hover" @click="redirigirInfopeli(pelicula.peliculaID)">
    <img :src="'multimedia/' + pelicula.imagen" :alt="pelicula.titulo" class="pelicula-image rounded-image">
  </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue'; 
import { useRouter } from 'vue-router';

const props = defineProps({
  pelicula: {
    type: Object,
    required: true,
  },
});

const router = useRouter();

function redirigirInfopeli(peliculaID: number) {
  router.push({ name: 'InfoPelicula', params: { movieId: peliculaID.toString() } });
}
</script>

<style scoped>
.pelicula img {
  width: 100%; 
  display: block; 
  border-radius: 10px;
  transition: filter 0.3s; 
}

.pelicula-hover:hover img {
  filter: brightness(80%);
  cursor: pointer; 
}
</style>