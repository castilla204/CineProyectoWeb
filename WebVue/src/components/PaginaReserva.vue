
<template>
  <div>
    <Butacas :sesionID="parseInt($route.params.sesionID)" />
  </div>
</template>

<script setup>
import Butacas from '../components/Butacas.vue';
import { useReservaStore } from '../store/ReservaStore';
</script>
