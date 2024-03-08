<template>
  <div class="general">
    <PresentacionCine @scroll-down="AccionScrollDown" />
    <Cartelera ref="componenteCartelera" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import Cartelera from './Cartelera.vue';
import PresentacionCine from './PresentacionCine.vue';

const componenteCartelera = ref(null as InstanceType<typeof Cartelera> | null);

const AccionScrollDown = () => {
  if (componenteCartelera.value) {
    const carteleraComponent = componenteCartelera.value.$el;
    if (carteleraComponent) {
      carteleraComponent.scrollIntoView({ behavior: 'smooth' });
    }
  }
};
</script>

<style scoped>
.general {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: black;
}
</style>