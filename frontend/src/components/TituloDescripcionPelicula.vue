<template>
  <div class="pelicula-info" v-if="pelicula">
    <h1 id="tituloPelicula">{{ pelicula.titulo }}</h1>
    <p id="datosPelicula">{{ pelicula.descripcion }}</p>
    <p id="datosPelicula">Director: {{ pelicula.director }}</p>
    <p id="datosPelicula">Actores: {{ pelicula.actores }}</p>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { useSesionesStore } from '../store/SesionStore';

interface Pelicula {
  titulo: string;
  descripcion: string;
  director: string;
  actores: string;
}

const sesionesStore = useSesionesStore();
const pelicula = computed<Pelicula | null>(() => sesionesStore.pelicula);
</script>

<style scoped>
.pelicula-info {
  color: white;
  padding: 20px;
  width: 100%;
}

#tituloPelicula {
  font-size: 25px;
  font-family: 'Helvetica';
  margin-bottom: 2%;
}

#datosPelicula {
  font-size: 20px;
  font-family: 'HelveticaThin';
  margin-top:2%;
}

@media (max-width: 768px) {
  #datosPelicula {
    font-size: 18px;
    font-family: 'HelveticaThin';
    margin-bottom: 0;
  }
}
</style>

<style scoped>

.pelicula-info {
  color: white;
  padding: 20px;
  width: 100%;
}

#tituloPelicula{
  font-size: 25px;
  font-family: 'Helvetica';
  margin-bottom: 2%;
}
#datosPelicula{
  font-size: 20px;
  font-family: 'HelveticaThin';
  margin-bottom: 0;
}
@media (max-width: 768px) {
  #datosPelicula{
    font-size: 18px;
    font-family: 'HelveticaThin';
    margin-bottom: 0;
  }
}
</style>