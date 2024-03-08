<template>
  <div id="ticketForm">
    <h1 class="titulocartelera">CARTELERA</h1>
    <p class="subtitulo1cartelera">CINE PARA TODA LA FAMILIA</p>
    <div class="linearoja"></div>
    <div class="contenedorpeliculas">
      <!-- Cargar las primeras 5 películas -->
      <div class="pelicula-group">
        <Pelicula
          v-for="(pelicula, index) in primeraFila"
          :key="pelicula.peliculaID"
          :pelicula="pelicula"
        />
      </div>
      <!-- Mostrar el subtitulo si hay más de 5 películas -->
      <div v-if="CargarSubtitulo" class="subtitulo-group">
        <p class="subtitulo1cartelera">NUEVAS PELÍCULAS</p>
        <div class="linearoja"></div>
      </div>
      <!-- Cargar la segunda fila -->
      <div class="pelicula-group">
        <Pelicula
          v-for="(pelicula, index) in segundaFila"
          :key="pelicula.peliculaID"
          :pelicula="pelicula"
        />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, computed, ref } from 'vue';
import { usePeliculasStore } from '../store/PeliculaStore';
import Pelicula from './Pelicula.vue';

interface Pelicula {
  peliculaID: number;
}

const almacenPeliculas = usePeliculasStore();

const peliculas = ref<Pelicula[]>([]);

onMounted(async () => {
  await almacenPeliculas.obtenerPeliculas();
  peliculas.value = almacenPeliculas.peliculas; 
});

const CargarSubtitulo = computed(() => {
  return peliculas.value.length > 5;
});

const primeraFila = computed(() => peliculas.value.slice(0, 5));
const segundaFila = computed(() => peliculas.value.slice(5));
</script>

<style scoped>
.pelicula-group {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  gap: 20px;
}

.contenedorpeliculas {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.subtitulo-group {
  width: 100%; 
  margin-top: 40px; 
}

.linearoja {
  width: 80%; 
  margin-left: auto;
  margin-right: auto;
}

.subtitulo1cartelera {
  font-size: 20px;
  color: white;
  font-family: 'HelveticaThin';

  margin-bottom: 20px; 
}

.linearoja {
  background-color: darkred;
  height: 6px;
  margin-bottom: 20px;
}

#ticketForm {
  width: 100%;
  text-align: center;
}

.pelicula {
  width: calc(15% - 20px); 
  margin: 10px; 
}

.pelicula img {
  width: 100%; 
  border-radius: 10px; 
  display: block; 
}
@media screen and (max-width: 768px) {
  .pelicula{
    width: 40%;
  }
}
</style>