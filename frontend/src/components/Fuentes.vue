<template>
  <div></div>
</template>

<script setup lang="ts">
import { onMounted } from 'vue';

onMounted(() => {
  const fontStyles = `
    @font-face {
      font-family: 'Helvetica'; 
      src: url('/fuentes/HelveticaNowText-Regular.woff') format('woff'); 
      font-weight: normal;
      font-style: normal;
    }
    @font-face {
      font-family: 'HelveticaBold'; 
      src: url('/fuentes/HelveticaNowText-Bold.woff') format('woff');
      font-weight: normal;
      font-style: normal;
    }
    @font-face {
      font-family: 'HelveticaThin'; 
      src: url('/fuentes/HelveticaNowText-ExtraLight.woff') format('woff'); 
      font-weight: normal;
      font-style: normal;
    }
    @font-face {
      font-family: 'HelveticaCursiva'; 
      src: url('/fuentes/HelveticaNowText-ExtLtIta.woff') format('woff'); 
      font-weight: normal;
      font-style: normal;
    }
  `;
  const style = document.createElement('style');
  style.appendChild(document.createTextNode(fontStyles));
  document.head.appendChild(style);
});
</script>

<style scoped>
</style>