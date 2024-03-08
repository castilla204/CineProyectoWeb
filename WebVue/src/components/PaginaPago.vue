<template>
  <div>
    <MetodoDePago></MetodoDePago>
    <BotonComprar></BotonComprar>
  </div>
</template>


<script lang="ts">
import { defineComponent } from 'vue';
import MetodoDePago from './MetodoDePago.vue';
import BotonComprar from './BotonComprar.vue';

export default defineComponent({
  components: {
    MetodoDePago,
    BotonComprar
  }
});
</script>


<style scoped>



.header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  background-color: rgb(196, 0, 0);
  height: 90px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  z-index: 1000;
  width: 100%;
}
</style>