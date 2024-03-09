<template>
    <div>
      <form @submit.prevent="submitForm">
        <input v-model="formulario.id" type="number" placeholder="ID de la película" required />
        <input v-model="formulario.imagen" type="text" placeholder="URL de la imagen" required />
        <input v-model="formulario.titulo" type="text" placeholder="Título" required />
        <input v-model="formulario.director" type="text" placeholder="Director" required />
        <input v-model="formulario.actores" type="text" placeholder="Actores" required />
        <textarea v-model="formulario.descripcion" placeholder="Descripción" required></textarea>
        <button type="submit">Editar Película</button>
      </form>
      <button @click="limpiarFormulario">Limpiar Formulario</button>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { usePeliculasStore } from '@/store/PeliculaStore'; 
  
  const formulario = ref({
    id: null,
    imagen: '',
    titulo: '',
    director: '',
    actores: '',
    descripcion: '',
  });
  const store = usePeliculasStore();
  
  const submitForm = () => {
    store.editarPelicula(formulario.value.id, {
      imagen: formulario.value.imagen,
      titulo: formulario.value.titulo,
      director: formulario.value.director,
      actores: formulario.value.actores,
      descripcion: formulario.value.descripcion,
    });
    limpiarFormulario();
  };
  
  const limpiarFormulario = () => {
    formulario.value = { id: null, imagen: '', titulo: '', director: '', actores: '', descripcion: '' };
  };
  </script>