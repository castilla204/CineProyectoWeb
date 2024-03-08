<template>
  <div class="general" v-if="pelicula">
    <div id="movieDetails" class="movieDetails">
        <div class="DatosPelicula">
            <h1 id="movieTitle">{{ pelicula.titulo }}</h1>
            <p id="movieDescription">{{ pelicula.descripcion }}</p>
            <button class="boton" @click="RedirigirButacas(pelicula.id)">Comprar</button>
        </div>
        <div class="imagenpelicula">
            <img v-if="pelicula.imagen" :src="`multimedia/${pelicula.imagen}`" class="imagen" :alt="pelicula.titulo">
        </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

export default defineComponent({
  setup() {
    const pelicula = ref(null);
    const isLoading = ref(false);
    const router = useRouter();

    
    const CargaPelicula = async () => {
      isLoading.value = true;
      try {
        const IdPelicula =  router.currentRoute.value.query.movieId; // Acceder al objeto de la ruta actual a través de router
        const response = await fetch(`http://localhost:8001/Pelicula/${IdPelicula}`);
        pelicula.value = await response.json();
      } catch (error) {
        console.error(error);
      } finally {
        isLoading.value = false;
      }
    };

    const RedirigirButacas = (movieId: string) => {
      router.push({ name: 'Butacas', query: { movieId: movieId }})};

    onMounted(CargaPelicula);
    


    

    return { pelicula, isLoading, RedirigirButacas };
  },
});
</script>



<style scoped>
.general{
  height: 100vh;
  background: black;
}

/*IMAGEN PELICULA*/
.imagen{
  height:97vh;
}

/*TEXTO PELICULA*/
.movieDetails{
  display: flex;
}

.DatosPelicula{
  color: white;
}
/*BOTON*/
.boton{
  height:30%;
}

</style>