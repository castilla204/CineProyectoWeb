<template>
  <div class="general" v-if="pelicula">
    <div id="movieDetails" class="movieDetails">
        <div class="DatosPelicula">
            <h1 id="movieTitle">{{ pelicula.titulo }}</h1>
            <p id="movieDescription">{{ pelicula.descripcion }}</p>
            <SesionesDisponibles :sessions="sessions" />
        </div>
        <div class="imagenpelicula">
            <img v-if="pelicula.imagen" :src="`multimedia/${pelicula.imagen}`" class="imagen" :alt="pelicula.titulo">
        </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
import SesionesDisponibles from './SesionesDisponibles.vue';
import { SesionesStore } from '../store/SesionStore';

const pelicula = ref(null);
const isLoading = ref(false);
const router = useRouter();
const almacenSesiones = SesionesStore();

const cargaPelicula = async () => {
  isLoading.value = true;
  try {
    // Extraer el movieId de la url
    const movieId = router.currentRoute.value.params.movieId;
    // Si el MovieId no existe
    if (!movieId) {
      throw new Error('Invalid movieId');
    }
    const response = await fetch(`http://localhost:8001/Pelicula/${movieId}`);
    pelicula.value = await response.json();

    await almacenSesiones.ObtenerSesionesPelicula(movieId); //llamar al sesionstore de la libreria pinia a la funcion fetch 
  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }
};

onMounted(cargaPelicula);
</script>
<style scoped>
.general{
  height: 100vh;
  background: black;
}

.imagen{
  height:97vh;
}

.movieDetails{
  display: flex;
}

.DatosPelicula{
  color: white;
}

.boton{
  height:30%;
}
</style>