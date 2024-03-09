<template>
    <div>
      <form @submit.prevent="submitForm">
        <input v-model="idPelicula" type="number" placeholder="ID de la película" required />
        <button type="submit">Eliminar Película</button>
      </form>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { usePeliculasStore } from '@/store/PeliculaStore'; 
  
  const idPelicula = ref(null);
  const store = usePeliculasStore();
  
  const submitForm = () => {
    if (idPelicula.value !== null) {
      store.eliminarPelicula(idPelicula.value);
    }
    idPelicula.value = null;
  };
  </script>