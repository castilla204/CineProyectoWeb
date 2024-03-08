<script setup lang="ts">
import Cabecera from './components/Cabecera.vue';
import { defineComponent } from 'vue';
import Fuentes from './components/Fuentes.vue';//marca error pero cumple la función
import PaginaPago from './components/PaginaPago.vue';
import HomePage from './components/Homepage.vue';
import InfoPelicula from './components/InfoPelicula.vue';

</script>
<template>
    <Cabecera></Cabecera>
    
    <router-view /> 
    <Fuentes></Fuentes>
  </template>
  

  
  <style scoped>

  </style>