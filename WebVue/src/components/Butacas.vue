<template>
  <div class="contenedorButacas">
    <div v-for="(fila, index) in filas" :key="index" class="fila">
      <svg
        v-for="butaca in fila"
        :key="butaca.id"
        :id="'butaca-' + butaca.id"
        class="butaca"
        @click="comprobarButaca(butaca.id)"
        :style="{ fill: butaca.ocupada ? 'red' : (butacaSeleccionada.includes(butaca.id) ? 'blue' : 'black') }"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 24 24"
        width="100"
        height="100"
      >
        <path d="M0 0h24v24H0z" fill="none" />
        <path fill-rule="evenodd" d="M4 4h16v2H4V4zm16 4v10c0 1.1-.9 2-2 2H6c-1.1 0-2-.9-2-2V8c0-1.1.9-2 2-2h12c1.1 0 2 .9 2 2zM6 18h12V8H6v10zm3-4h6v2H9v-2z"/>
      </svg>
    </div>
    <button @click="realizarReserva">Reservar</button>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed, ref } from 'vue';
import { ButacaStore } from '../store/ButacaStore';
import { useReservaStore } from '../store/ReservaStore';
import { useRouter } from 'vue-router'; 

export default defineComponent({
  props: {
    sesionID: {
      type: Number,
      required: true
    }
  },
  setup(props) {
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
        router.push({ name: 'PaginaPago' });
      } catch (error) {
        console.error('Error al realizar la reserva:', error);
      }
    };

    return {
      filas,
      comprobarButaca,
      realizarReserva,
      butacaSeleccionada
    };
  }
});
</script>

<style scoped>
.contenedorButacas {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.fila {
  display: flex;
}

.butaca {
  margin: 5px;
  cursor: pointer;
}
</style>