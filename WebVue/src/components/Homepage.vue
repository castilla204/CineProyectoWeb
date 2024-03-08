<template>
  <div class="general">
    <!--Home-->
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
    <!--Cartelera-->
    <section class="cartelera">
      <div id="ticketForm">
        <h1 class="titulocartelera">CARTELERA</h1>
        <p class="subtitulo1cartelera">CINE PARA TODA LA FAMILIA</p>
        <div class="linearoja"></div>
        <div class="contenedorpeliculas" id="contenedorpeliculas">
          <!-- Cargar las primeras 5 películas -->
          <div class="movie-group">
            <img v-for="(movie, index) in primeraFila" :key="movie.id" :src="'multimedia/' + movie.imagen" :alt="movie.titulo" @click="RedirigirInfopeli(movie.id, index)" class="movie-image rounded-image">
          </div>


          <!-- Mostrar el subtítulo si hay mas de 5 contenedorpeliculas -->
          <div v-if="CargarSubtitulo" class="subtitulo-group">
            <p class="subtitulo1cartelera">NUEVAS PELÍCULAS</p>
            <div class="linearoja"></div>
          </div>
          <!-- Cargar la segunda fila -->
          <div class="movie-group">
            <img v-for="(movie, index) in segundaFila" :key="movie.id" :src="'multimedia/' + movie.imagen" :alt="movie.titulo" @click="RedirigirInfopeli(movie.id, index)" class="movie-image rounded-image">
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useRouter } from 'vue-router'; 

export default defineComponent({
  setup() {
    const peliculas = ref([]);
    const isLoading = ref(false);
    const CargarSubtitulo = ref(false);
    const primeraFila = ref([]);
    const segundaFila = ref([]);
    const router = useRouter(); 

    const loadMovies = async () => {
      isLoading.value = true;
      try {
        const response = await fetch('http://localhost:8001/Pelicula');
        peliculas.value = await response.json();
        DividirpeliculasEnFilas();
      } catch (error) {
        console.error(error);
      } finally {
        isLoading.value = false;
      }
    };

    onMounted(loadMovies);

    const DividirpeliculasEnFilas = () => {
      if (peliculas.value.length >= 5) {
        CargarSubtitulo.value = true;
        primeraFila.value = peliculas.value.slice(0, 5);
        segundaFila.value = peliculas.value.slice(5);
      } else {
        primeraFila.value = peliculas.value;
      }
    };

    const AccionScrollDown = () => {
      const contenedorpeliculas = document.querySelector('.contenedorpeliculas');
      if (contenedorpeliculas) {
        contenedorpeliculas.scrollIntoView({ behavior: 'smooth' });
      }
    };

    const RedirigirInfopeli = (movieId: string, index: number) => {
      router.push({ name: 'InfoPelicula', query: { movieId: movieId } });
    };

    return { primeraFila, segundaFila, isLoading, AccionScrollDown, RedirigirInfopeli, CargarSubtitulo };
  },
});
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
</style>
