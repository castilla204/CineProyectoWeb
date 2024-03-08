<template>
  <div class="sesiones-container">
    <h1 id="titulosesiones">Sesiones Disponibles</h1>
    <div v-for="(sesion, index) in sesiones" :key="sesion.sesionID" class="sesion" :style="{ backgroundColor: ColoresDivSesiones[index % ColoresDivSesiones.length] }" @click="redirigirReserva(sesion.sesionID)">
      <div class="sesion-info">
        <p>{{ sesion.fechaHora }}</p>
        <p>{{ sesion.nombreSala }}</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { useSesionesStore } from '../store/SesionStore';
import { useRouter } from 'vue-router';

interface Sesion {
  sesionID: number;
  fechaHora: string;
  nombreSala: string;
}

const almacenSesiones = useSesionesStore();

const sesiones = computed<Sesion[]>(() => almacenSesiones.sesiones);

const ColoresDivSesiones = ['#9E2A2B', '#AF601A', '#B9770E', '#C68407', '#D4AC0D'];

const router = useRouter();
const redirigirReserva = (sesionID: number) => {
  router.push({ name: 'PaginaReserva', params: { sesionID: sesionID.toString() } });
};
</script>

<style scoped>
.sesiones-container {
  display: flex;
  flex-direction: column;
  padding: 20px;
}

#titulosesiones {
  font-family: 'Helvetica', sans-serif;
  color: #ffffff; 
  margin-bottom: 20px; 
  font-size: 28px; 
}

.sesion {
  cursor: pointer;
  margin-bottom: 20px;
  border-radius: 15px; 
  border: none; 
  padding: 20px;
  width: 80%; 
  max-width: 600px; 
  box-shadow: 0 4px 8px rgba(0,0,0,0.2); 
  font-family: 'Helvetica', sans-serif;
  background-color: #fff; 
  transition: transform 0.2s;
}

.sesion:hover {
  transform: scale(1.05);
}

.sesion-info {
  display: flex;
  justify-content: space-between;
  font-size: 18px; 
}

.sesion p {
  margin: 5px 0; 
  color: #333; 
}
@media (max-width: 768px) {
  .sesion {
    padding: 20px; 
    margin-bottom: 10px; 
    width: 100%; 
  }

  .sesion-info {
    flex-direction: column; 
    text-align: center; 
  }
}
</style>