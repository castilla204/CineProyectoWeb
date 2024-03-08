<template>
  <div class="sesiones-container">
    <h1 id="titulosesiones">Sesiones Disponibles</h1>
    <div v-for="(sesion, index) in sesiones" :key="sesion.sesionID" class="sesion" :style="{ backgroundColor: ColoresDivSesiones[index % ColoresDivSesiones.length] }" @click="redirigirReserva(sesion.sesionID)">
      <div class="sesion-info" >
        <p>{{ sesion.fechaHora }}</p>
        <p>{{ sesion.nombreSala }}</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue';
import { SesionesStore } from '../store/SesionStore';
import { useRouter } from 'vue-router'; 

const router = useRouter(); 

const almacenSesiones = SesionesStore();
const sesiones = ref([]);

watch(() => almacenSesiones.sesiones, (nuevasSesiones) => {
  sesiones.value = nuevasSesiones;
});

const ColoresDivSesiones = ['#9E2A2B',  '#AF601A', '#B9770E', '#C68407', '#D4AC0D'];
const redirigirReserva = (sesionID) => {
  router.push({ name: 'PaginaReserva', params: { sesionID: sesionID.toString() } });
};
</script>

<style scoped>
.sesiones-container {
  flex-direction: column;
  align-items: center;
}
#titulosesiones{
  font-family: 'Helvetica';
}
.sesion {
  cursor: pointer; /* Cambia el cursor al pasar sobre las sesiones para indicar que son clicables */
  margin-bottom: 20px;
  border-radius: 10px;
  border: 1px solid #ccc;
  padding: 10px;
  width: 300px;
  font-family: 'HelveticaThin';
}

.sesion-info {
  display: flex;
  justify-content: space-between;
}
</style>