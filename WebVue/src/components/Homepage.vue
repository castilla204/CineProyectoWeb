<template>
  <div class="general">
    <PresentacionCine></PresentacionCine>
    <cartelera></cartelera>
  </div>
  </template>
<script>

import Cartelera from './Cartelera.vue'; 
import PresentacionCine from './PresentacionCine.vue'

export default {
  name: 'Homepage',
  components: {
    Cartelera,
    PresentacionCine
  },
  methods: {
    AccionScrollDown() {
      const carteleraComponent = this.$refs.componenteCartelera.$el; 
      carteleraComponent.scrollIntoView({ behavior: 'smooth' }); 
    },
  },
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