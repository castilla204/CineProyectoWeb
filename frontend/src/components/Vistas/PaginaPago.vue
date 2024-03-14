<template>
  <div class="general">
    <CompraExitosa />
  </div>
</template>

<script setup lang="ts">
import MetodoDePago from '../MetodoDePago.vue';
import BotonComprar from '../BotonComprar.vue';
import CompraExitosa from '../CompraExitosa.vue'
</script>

<style scoped>
.general{
  padding: 80px;
  height: 100vh;
  background-color: rgb(6, 172, 0)};
</style>