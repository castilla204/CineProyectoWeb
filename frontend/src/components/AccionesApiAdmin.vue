<template>
  <div class="general">
    <h2 class="tituloeditarocrear">{{ idPeliculaActual ? 'Editar Película' : 'Crear Película' }}</h2>
    <form @submit.prevent="formularioenviardatos">
      <input v-model="formulario.imagen" type="text" :placeholder="$t('AccionesAdmin.textPlaceholder1')" required
        class="campoformulario" />
      <input v-model="formulario.titulo" type="text" :placeholder="$t('AccionesAdmin.textPlaceholder2')" required
        class="campoformulario" />
      <input v-model="formulario.director" type="text" :placeholder="$t('AccionesAdmin.textPlaceholder3')" required
        class="campoformulario" />
      <input v-model="formulario.actores" type="text" :placeholder="$t('AccionesAdmin.textPlaceholder4')" required
        class="campoformulario" />
      <textarea v-model="formulario.descripcion" :placeholder="$t('AccionesAdmin.textPlaceholder5')" required
        class="campodescripcion"></textarea>
      <button type="submit" class="botoneditarocrear">{{ idPeliculaActual ? 'Editar' : 'Guardar' }} {{
      $t('AccionesAdmin.text1') }}</button>
      <button type="button" @click="cancelarEdicion" class="botoncancelar">{{
      $t('AccionesAdmin.text2') }}</button>
    </form>

    <h2 class="tituloeditarocrear">{{
      $t('AccionesAdmin.text3') }}</h2>
    <div v-if="isLoading" class="loading">C{{
      $t('AccionesAdmin.text4') }}</div>
    <div v-else>
      <ul>
        <li v-for="pelicula in peliculas" :key="pelicula.peliculaID" class="peliculalineadatos">
          <span>{{ pelicula.titulo }} - {{ pelicula.director }}</span>
          <div>
            <button @click="editarPelicula(pelicula)" class="botoneditar">{{
      $t('AccionesAdmin.text5') }}</button>
            <button @click="eliminarPelicula(pelicula.peliculaID)" class="botonborrar">{{
      $t('AccionesAdmin.text6') }}</button>
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import { usePeliculasStore, Pelicula } from '../store/PeliculaStore'; 

const formulario = ref<Pelicula>({
  peliculaID: 0,
  imagen: '',
  titulo: '',
  director: '',
  actores: '',
  descripcion: '',
});
const idPeliculaActual = ref<number | null>(null);
const store = usePeliculasStore();

const formularioenviardatos = () => {
  if (idPeliculaActual.value) {
    store.editarPelicula(idPeliculaActual.value, formulario.value);
  } else {
    store.agregarPelicula(formulario.value);
  }
  limpiarFormulario();
};

const cancelarEdicion = () => {
  limpiarFormulario();
};

const editarPelicula = (pelicula: Pelicula) => {
  idPeliculaActual.value = pelicula.peliculaID;
  formulario.value = { ...pelicula };
};

const eliminarPelicula = async (id: number) => {
  await store.eliminarPelicula(id);
  await obtenerPeliculas();
};

const limpiarFormulario = () => {
  formulario.value = { peliculaID: 0, imagen: '', titulo: '', director: '', actores: '', descripcion: '' };
  idPeliculaActual.value = null;
};

const obtenerPeliculas = async () => {
  await store.obtenerPeliculas();
};

const peliculas = ref<Pelicula[]>([]); 


watch(() => store.isLoading, async (isLoading) => {
  if (!isLoading) {
    peliculas.value = store.peliculas; 
  }
});


onMounted(obtenerPeliculas);

const isLoading = store.isLoading;
</script>

<style scoped>
.general {
  background-color: #111;
  padding: 20px;
  border-radius: 5px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
  font-family: 'HelveticaThin';

}

.tituloeditarocrear {
  color: #fff;
  font-size: 1.5rem;
  margin-bottom: 15px;
  font-family: 'Helvetica';
}

.campoformulario,
.campodescripcion {
  width: 100%;
  margin-bottom: 10px;
  padding: 8px;
  border: 1px solid #444;
  border-radius: 4px;
  background-color: #222;
  color: #fff;
}

.botoneditarocrear,
.botoncancelar {
  padding: 8px 15px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  margin-right: 10px;
}

.botoneditarocrear:hover,
.botoncancelar:hover {
  background-color: #0056b3;
}

.peliculalineadatos {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 10px;
}

.botoneditar,
.botonborrar {
  padding: 6px 10px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.botoneditar:hover,
.botonborrar:hover {
  background-color: #0056b3;
}
</style>