<script setup lang="ts">

import Cabecera from './components/Cabecera.vue';
import { defineComponent } from 'vue';
import Fuentes from './components/Fuentes.vue';
import HomePage from './components/Homepage.vue';
import InfoPelicula from './components/InfoPelicula.vue';

</script>
<template>
    <Cabecera class="Cabecera"></Cabecera>
    
    <router-view /> 
    <Fuentes></Fuentes>
  </template>

