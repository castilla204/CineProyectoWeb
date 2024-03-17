<template>
  <div id="ticketForm">
    <div v-for="(fila) in filas" >
      <div class="espacio"></div> 
      <div class="linearoja"></div> 
      <div class="contenedorpeliculas">
        <div class="pelicula-group">
          <Pelicula
            v-for="pelicula in fila"   
            :key="pelicula.peliculaID" 
            :pelicula="pelicula" 
          />
          <!-- el :key usado para que se asigne un valor unico a cada pelicula-->
          <!-- el :pelicula="pelicula"  el :pelicula indica que se manda la informacion de la paleicula al prop pelicula del componente hijo-->
          <!-- en este caso la clase Pelicula y se le manda la variable pelicula-->
        
          
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

const peliculas = ref<Pelicula[]>([]);//Inixiamos la variable peliculas con in array vacio

onMounted(async () => {
  await almacenPeliculas.obtenerPeliculas();
  peliculas.value = almacenPeliculas.peliculas; 
});

const filas = computed(() => {//dividimos las peliculas en filas de 5 (filascontiene un array de arrays cada fila el array de peliculas con )
  const peliculasDivididasen5 = [];
  for (let i = 0; i < peliculas.value.length; i += 5) {
    peliculasDivididasen5.push(peliculas.value.slice(i, i + 5));
  }
  return peliculasDivididasen5;
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
  height: 20px; 
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