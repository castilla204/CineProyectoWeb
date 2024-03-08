<template>
  <div class="general">
    <Butacas :sesionID="parseInt(Array.isArray($route.params.sesionID) ? $route.params.sesionID.join('') : $route.params.sesionID)" />
  </div>
</template>

<script setup lang="ts">
import Butacas from '../components/Butacas.vue';
import { useReservaStore } from '../store/ReservaStore';
</script>

<style scoped>
.general {
  background-color: black;
  height: 100vh;
}
</style>