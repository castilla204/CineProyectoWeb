<template>
    <div id="ticketForm">
      <h1 class="titulocartelera">CARTELERA</h1>
      <p class="subtitulo1cartelera">CINE PARA TODA LA FAMILIA</p>
      <div class="linearoja"></div>
      <div class="contenedorpeliculas" id="contenedorpeliculas">
        <!-- Cargar las primeras 5 películas -->
        <div class="pelicula-group">
          <img v-for="(pelicula, index) in primeraFila" :key="pelicula.peliculaID" :src="'multimedia/' + pelicula.imagen" :alt="pelicula.titulo" @click="RedirigirInfopeli(pelicula.peliculaID)" class="pelicula-image rounded-image">
        </div>


        <!-- Mostrar el subtitulo si hay mas de 5 peliculas -->
        <div v-if="CargarSubtitulo" class="subtitulo-group">
          <p class="subtitulo1cartelera">NUEVAS PELÍCULAS</p>
          <div class="linearoja"></div>
        </div>
        <!-- Cargar la segunda fila -->
        <div class="pelicula-group">
          <img v-for="(pelicula, index) in segundaFila" :key="pelicula.peliculaID" :src="'multimedia/' + pelicula.imagen" :alt="pelicula.titulo" @click="RedirigirInfopeli(pelicula.peliculaID)" class="pelicula-image rounded-image">
        </div>
      </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed } from 'vue';
import { PeliculasStore } from '../store/PeliculaStore'; 
import { useRouter } from 'vue-router';

export default defineComponent({
  setup() {
    const router = useRouter();
    const almacenPeliculas = PeliculasStore();

    onMounted(() => {
      almacenPeliculas.ObtenerPeliculas();
    });

    const CargarSubtitulo = computed(() => {
      return almacenPeliculas.peliculas.length > 5;
    });

    return {
      primeraFila: computed(() => almacenPeliculas.peliculas.slice(0, 5)),
      segundaFila: computed(() => almacenPeliculas.peliculas.slice(5)),
      isLoading: computed(() => almacenPeliculas.isLoading),
      CargarSubtitulo,
      RedirigirInfopeli: (movieId: number) => {
      router.push({ name: 'InfoPelicula', params: { movieId: movieId.toString() } });
},
    };
  },
});
</script>

<style scoped>
.cartelera {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: 80px;
}

.titulocartelera {
  font-size: 20px;
  margin-left: 10%;
  color: white;
  font-family: 'Helvetica';
  text-align: left;
}

.subtitulo1cartelera {
  font-family: 'HelveticaThin';
  margin-left: 10%;
  color: white;
  text-align: left;
  font-size: 20px; 
  margin-bottom: 0%;
}

.linearoja {
  margin-left: 10%;
  width: 80%;
  height: 6px;
  background-color: darkred;
}

.contenedorpeliculas img {
  width: 13%;
  margin: 30px;
}

.rounded-image {
  border-radius: 10px;
}

#ticketForm {
  width: 100%;
  text-align: center;
}
</style>../store/PeliculaStore