<template>
  <div class="sesiones-container">
    <h1>Sesiones Disponibles</h1>
    <div v-for="(sesion, index) in sessions" :key="sesion.sesionID" class="sesion" :style="{ backgroundColor: sessionColors[index % sessionColors.length] }">
      <div class="sesion-info">
        <p>{{ sesion.fechaHora }}</p>
        <p>{{ sesion.nombreSala }}</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue';
import { SesionesStore } from '../store/SesionStore';

// Obtener las sesiones de la tienda
const almacenSesiones = SesionesStore();

// Definir una referencia reactiva para sessions
const sessions = ref([]);

// Observar cambios en el store y actualizar con los cambios
watch(() => almacenSesiones.sessions, (newSessions) => {
  sessions.value = newSessions;
});

// Colores para las div de lsas sesiones
const sessionColors = ['#FFC0CB', '#87CEEB', '#90EE90', '#FFD700', '#CD5C5C', '#FFA07A']; 
</script>

<style scoped>
.sesiones-container {
  flex-direction: column;
  align-items: center;
}

.sesion {
  margin-bottom: 20px;
  border-radius: 10px;
  border: 1px solid #ccc;
  padding: 10px;
  width: 300px;
}

.sesion-info {
  display: flex;
  justify-content: space-between;
}
</style>