<template>
  <div id="ticketForm">
    <h1 class="titulocartelera">CARTELERA</h1>
    <div v-for="(fila, index) in filas" :key="index">
      <div class="espacio"></div> <!-- Espacio entre las líneas rojas y la fila de películas -->
      <div class="linearoja"></div> <!-- Línea roja entre grupos de películas -->
      <div class="contenedorpeliculas">
        <div class="pelicula-group">
          <Pelicula
            v-for="pelicula in fila"
            :key="pelicula.peliculaID"
            :pelicula="pelicula"
          />
        </div>
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

const filas = computed(() => {
  const peliculasChunked = [];
  for (let i = 0; i < peliculas.value.length; i += 5) {
    peliculasChunked.push(peliculas.value.slice(i, i + 5));
  }
  return peliculasChunked;
});
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

.espacio {
  height: 20px; /* Altura del espacio entre las líneas rojas y la fila de películas */
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