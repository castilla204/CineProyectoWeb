<template>
  <div class="general">
    <MetodoDePago />
    <BotonComprar />
  </div>
</template>

<script setup lang="ts">
import MetodoDePago from './MetodoDePago.vue';
import BotonComprar from './BotonComprar.vue';
</script>

<style scoped>
.general{
  padding: 80px;
  height: 100vh;
  background-color: black;
}
</style>