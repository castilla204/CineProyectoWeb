<template>
  <div class="contenedor">
    <h2 class="titulo">Seleccione sus butacas</h2>
    <div class="contenedorButacas">
      <div v-for="(fila, index) in filas" :key="index" class="fila">
        <svg
          v-for="butaca in fila"
          :key="butaca.id"
          :id="'butaca-' + butaca.id"
          @click="comprobarButaca(butaca.id)"
          :class="{'ocupada': butaca.ocupada, 'seleccionada': butacaSeleccionada.includes(butaca.id)}"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 24 24"
          width="100"
          height="100"
        >
          <path d="M0 0h24v24H0z" fill="none"/>
          <path fill="#f4c242" d="M7 10h10v4H7z"/>
          <path fill="#f48f42" d="M7 8h10v2H7z"/>
          <path fill="#f4af42" d="M4 9h3v6H4zM17 9h3v6h-3z"/>
        </svg>
      </div>
      <div class="pantallaCine"></div>
      <button @click="realizarReserva" :disabled="butacaSeleccionada.length === 0" class="botonReserva">Reservar</button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { ButacaStore } from '../store/ButacaStore';
import { useReservaStore } from '../store/ReservaStore';
import { useRouter } from 'vue-router'; 
import { defineProps } from 'vue';

const props = defineProps<{
  sesionID: number;
}>();

const butacaStore = ButacaStore();
const reservaStore = useReservaStore();
const butacas = computed(() => butacaStore.butacas);
const butacaSeleccionada = ref<number[]>([]);
const router = useRouter(); 

const filas = computed(() => {
  const resultado = [];
  for (let i = 0; i < butacas.value.length; i += 10) {
    resultado.push(butacas.value.slice(i, i + 10));
  }
  return resultado;
});

onMounted(async () => {
  await butacaStore.cargarButacas(props.sesionID);
});

const comprobarButaca = (id: number) => {
  const butaca = butacas.value.find(b => b.id === id);
  if (butaca && !butaca.ocupada) {
    const index = butacaSeleccionada.value.indexOf(id);
    if (index === -1) {
      butacaSeleccionada.value.push(id);
    } else {
      butacaSeleccionada.value.splice(index, 1);
    }
  }
};

const realizarReserva = async () => {
  try {
    await reservaStore.realizarReserva({
      sesionID: props.sesionID,
      usuarioID: 1,
      butacasIds: butacaSeleccionada.value
    });
    router.push({ name: 'PaginaPago', params: { sesionID: props.sesionID.toString() } });
  } catch (error) {
    console.error('Error al realizar la reserva:', error);
  }
};
</script>

<style scoped>
.contenedor {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.contenedorButacas {
  background-color: #f0f0f0;
  border-radius: 10px; 
  padding: px;
  box-shadow: 0 4px 8px rgba(255, 0, 0, 0.5); 
  margin-top: 10px; 
}

.titulo {
  font-size: 1.5rem;
  color: #ffffff;
  margin-bottom: 5px;
  font-family: 'Helvetica';
  margin-top: 4%; 
}

.fila {
  display: flex;
  justify-content: center; 
}

.butaca {
  margin: 0px; 
  cursor: pointer;
}
.butaca:hover svg{
  transform: scale(1.2); 
}

.pantallaCine {
  width: 80%; 
  height: 15px;
  background-color: #949494;
  margin: 10px auto; 
  border-radius: 2px;
}

.botonReserva {
  background-color: #4CAF50;
  color: white;
  padding: 10px 20px; 
  text-align: center;
  font-size: 14px;
  margin-top: 10px; 
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.ocupada path {
  opacity: 20%; 
  fill: rgb(255, 30, 0);
}
.seleccionada path {
opacity: 20%;
fill: blue;}


svg {
  width: 80px; 
  height: 80px;
}

@media screen and (max-width: 768px) {
  svg {
    width: 40px; 
    height: 80px;
  }
}


</style>