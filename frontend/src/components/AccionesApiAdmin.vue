<template>
  <div class="general">
    <h2 class="tituloeditarocrear">{{ idPeliculaActual ? 'Editar Película' : 'Crear Película' }}</h2>
    <form @submit.prevent="formularioenviardatos">
      <input v-model="formulario.imagen" type="text" placeholder="nombre imagen con extension" required class="campoformulario" />
      <input v-model="formulario.titulo" type="text" placeholder="Titulo" required class="campoformulario" />
      <input v-model="formulario.director" type="text" placeholder="Director" required class="campoformulario" />
      <input v-model="formulario.actores" type="text" placeholder="Actores" required class="campoformulario" />
      <textarea v-model="formulario.descripcion" placeholder="Descripción" required class="campodescripcion"></textarea>
      <button type="submit" class="botoneditarocrear">{{ idPeliculaActual ? 'Editar' : 'Guardar' }} Película</button>
      <button type="button" @click="cancelarEdicion" class="botoncancelar">Cancelar</button>
    </form>

    <h2 class="tituloeditarocrear">Listado de Películas</h2>
    <div v-if="isLoading" class="loading">Cargando...</div>
    <div v-else>
      <ul>
        <li v-for="pelicula in peliculas" :key="pelicula.peliculaID" class="peliculalineadatos">
          <span>{{ pelicula.titulo }} - {{ pelicula.director }}</span>
          <div>
            <button @click="editarPelicula(pelicula)" class="botoneditar">Editar</button>
            <button @click="eliminarPelicula(pelicula.peliculaID)" class="botonborrar">Eliminar</button>
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
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

const eliminarPelicula = (id: number) => {
  store.eliminarPelicula(id);
};

const limpiarFormulario = () => {
  formulario.value = { peliculaID: 0, imagen: '', titulo: '', director: '', actores: '', descripcion: '' };
  idPeliculaActual.value = null;
};

const peliculas = store.peliculas;
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